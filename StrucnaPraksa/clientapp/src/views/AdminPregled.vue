<template>
  <div>
    <b-button class="m-2" variant="success" @click="showOnlyPredane">
      Prikazi studente koji su predali sve dokumente
    </b-button>
    <b-button class="m-2" variant="danger" @click="showNepredano">
      Prikazi studente koji nisu predali sve dokumente
    </b-button>
    <br />
    <small v-if="filterRegex"
      >Pritisnite ocisti da bi prikazali sve studente</small
    >
    <b-input-group prepend="Pretrazite" class="mt-3">
      <b-form-input placeholder="..." v-model="filter"></b-form-input>
      <b-input-group-append>
        <b-button
          variant="info"
          @click="
            filter = null;
            filterRegex = null;
          "
          >Ocisti</b-button
        >
      </b-input-group-append>
    </b-input-group>
    <b-table
      class="mt-3"
      :busy.sync="isLoading"
      per-page="10"
      :current-page="currentPage"
      filtered
      show-empty
      small
      :filter="filterRegex ? filterRegex : filter"
      stacked="md"
      @filtered="onFilter"
      :items="studentiItems"
      :fields="fields"
    >
      <template v-slot:cell(anketa)="data">
        <div
          v-b-tooltip.hover
          :title="
            data.value === 'Predano'
              ? 'Pregledaj anketu'
              : 'Anketa nije predana'
          "
          :style="
            data.value === 'Predano'
              ? 'border-radius:5px; cursor:pointer;'
              : 'border-radius:5px; cursor:not-allowed;'
          "
          :class="
            data.value === 'Predano'
              ? 'bg-success p-1'
              : 'text-light bg-danger p-1'
          "
          @click="
            data.value === 'Predano' ? viewAnketa(data.item.anketa) : null
          "
        >
          <b>{{ data.value }}</b>
        </div>
      </template>
      <template v-slot:cell(izvjesce)="data">
        <div
          v-b-tooltip.hover
          :title="
            data.value === 'Predano'
              ? 'Preuzmi izvjesce'
              : 'Izvjesce nije predano'
          "
          :style="
            data.value === 'Predano'
              ? 'border-radius:5px; cursor:pointer;'
              : 'border-radius:5px; cursor:not-allowed;'
          "
          :class="
            data.value === 'Predano'
              ? 'bg-success p-1'
              : 'text-light bg-danger p-1'
          "
          @click="
            data.value === 'Predano'
              ? downloadDocument('Izvjesce', data.item.izvjesce.idUsera)
              : null
          "
        >
          <b>{{ data.value }}</b>
        </div>
      </template>
      <template v-slot:cell(dnevnik)="data">
        <div
          v-b-tooltip.hover
          :title="
            data.value === 'Predano' ? 'Preuzmi dnevnik' : 'Dnevnik nije predan'
          "
          :style="
            data.value === 'Predano'
              ? 'border-radius:5px; cursor:pointer;'
              : 'border-radius:5px; cursor:not-allowed;'
          "
          :class="
            data.value === 'Predano'
              ? 'bg-success p-1'
              : 'text-light bg-danger p-1'
          "
          @click="
            data.value === 'Predano'
              ? downloadDocument('Dnevnik', data.item.dnevnik.idUsera)
              : null
          "
        >
          <b>{{ data.value }}</b>
        </div>
      </template>
      <template v-slot:cell(actions)="data">
        <b-button
        @click="generatePdf(data)"
        v-if="data.item.anketa !== null || data.item.dnevnik !== null || data.item.izvjesce !== null" 
        variant="success">
          <b-spinner small v-if="loadingGenerateRow == data.index"/>
          <!-- <div   class="spinner-border" role="status"></div> -->
          <span v-else>
            Generiraj PDF
          </span>
        </b-button>
      </template>
    </b-table>
    <b-pagination
      v-model="currentPage"
      :total-rows="totalRows"
      :per-page="10"
      align="fill"
      size="sm"
      class="my-0"
    ></b-pagination>
    <Anketa
      :viewMode="true"
      v-if="anketaModal"
      :data="anketaToView"
      :model="anketaModal"
      @closeModal="closeAnketaModal"
    />
  </div>
</template>

<script>
import Anketa from '../components/Anketa.vue';

export default {
  components: {
    Anketa,
  },
  data() {
    return {
      loadingGenerateRow: null,
      totalRows: 0,
      currentPage: 1,
      anketaModal: false,
      anketaToView: null,
      filterRegex: null,
      filter: '',
      isLoading: false,
      godina: new Date(),
      fields: [
        { key: 'ime', label: 'Ime', sortable: true, sortDirection: 'desc' },
        {
          key: 'prezime',
          label: 'Prezime',
          sortable: true,
          sortDirection: 'desc',
        },
        {
          key: 'anketa',
          label: 'Anketa',
          sortable: true,
          sortDirection: 'desc',
          formatter: (value) => {
            return value ? 'Predano' : 'Nije predano';
          },
          filterByFormatted: true,
        },
        {
          key: 'dnevnik',
          formatter: (value) => {
            return value ? 'Predano' : 'Nije predano';
          },
          label: 'Dnevnik',
          sortable: true,
          filterByFormatted: true,
          sortDirection: 'desc',
        },
        {
          key: 'izvjesce',
          label: 'Izvjesce',
          sortable: true,
          filterByFormatted: true,
          formatter: (value) => {
            return value ? 'Predano' : 'Nije predano';
          },
          sortDirection: 'desc',
        },
        { key: 'actions', label: 'Akcije' },
      ],
      studentiItems: null,
    };
  },
  // computed: {
  //   totalRows() {
  //     return this.studentiItems? this.studentiItems.length : 0;
  //   }
  // },
  async mounted() {
    this.getDocuments();
  },
  methods: {
    async generatePdf(data) {     
      this.loadingGenerateRow = data.index;
      await this.downloadPrijavnica({fileUrl: `api/graph/generatePrijavnicaAdmin?userId=${data.item.idUsera}`});
      this.loadingGenerateRow = null;
    },
    onFilter(filteredItems) {
      this.totalRows = filteredItems.length;
      this.currentPage = 1;
    },
    viewAnketa(anketa) {
      this.anketaToView = anketa;
      this.anketaModal = true;
    },
    closeAnketaModal() {
      this.anketaModal = false;
      this.anketaToView = null;
    },
    async downloadDocument(doc, userId) {
      try {
        const fileResponse = await this.$axios.get(
          `api/dokumenti/get${doc}Admin?userId=${userId}`,
          {
            responseType: 'blob',
          }
        );
        const url = window.URL.createObjectURL(new Blob([fileResponse.data]));
        const link = document.createElement('a');
        link.href = url;
        const disposition = fileResponse.headers['content-disposition'];
        let filename = 'doc.pdf';
        if (disposition && disposition.indexOf('attachment') !== -1) {
          var filenameRegex = /filename[^;=\n]*=((['"]).*?\2|[^;\n]*)/;
          var matches = filenameRegex.exec(disposition);
          if (matches != null && matches[1]) {
            filename = matches[1].replace(/['"]/g, '');
          }
        }
        link.setAttribute('download', filename);
        document.body.appendChild(link);
        link.click();
      } catch (e) {
        this.$bvToast.toast('Pogreska kod preuzimanja dokumenta', {
            title: 'Error',
            autoHideDelay: 4000,
          });
      }
    },
    // async filterFunkcija(row, filter) {
    // },
    showOnlyPredane() {
      this.filterRegex = new RegExp('^((?!Nije predano).)*$');
    },
    showNepredano() {
      this.filterRegex = new RegExp('Nije predano');
    },
    async downloadPrijavnica(doc) {
      try {
        const fileResponse = await this.$axios.get(doc.fileUrl, {
          responseType: 'blob',
        });
        const url = window.URL.createObjectURL(new Blob([fileResponse.data]));
        const link = document.createElement('a');
        link.href = url;
        const disposition = fileResponse.headers['content-disposition'];
        let filename = 'doc.pdf';
        if (disposition && disposition.indexOf('attachment') !== -1) {
          var filenameRegex = /filename[^;=\n]*=((['"]).*?\2|[^;\n]*)/;
          var matches = filenameRegex.exec(disposition);
          if (matches != null && matches[1]) {
            filename = matches[1].replace(/['"]/g, '');
          }
        }
        link.setAttribute('download', filename);
        document.body.appendChild(link);
        link.click();
      } catch (e) {
        this.$bvToast.toast(
          `Pogreska kod generiranja dokumenata ${e.response.message}`,
          {
            title: 'Pogreska',
            autoHideDelay: 4000,
          }
        );
      }
    },
    async getDocuments() {
      try {
        const res = await this.$axios.get(
          `api/dokumenti/getDocumentsAdmin?godina=${this.godina.getFullYear()}`
        );
        // this.studentiItems = res.data;
        this.studentiItems = res.data;
        this.totalRows = this.studentiItems.length;
      } catch (e) {
        this.studentiItems = null;
      }
    },
  },
};
</script>

<style></style>
