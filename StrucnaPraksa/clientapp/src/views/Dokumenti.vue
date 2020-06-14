<template>
  <div class="dokumenti">
    <b-container>
      <b-spinner class="mt-5" v-if="loadingPage" />
      <OsnovniPodaci v-if="showForm" @submit="submitData" />
      <!-- TABLE -->
      <b-table-simple
        v-if="!showForm && !loadingPage"
        hover
        small
        caption-top
        responsive
      >
        <caption>
        </caption>
        <colgroup>
          <col />
          <col />
        </colgroup>
        <colgroup>
          <col />
          <col />
          <col />
        </colgroup>
        <colgroup>
          <col />
          <col />
        </colgroup>
        <b-thead head-variant="dark">
          <b-tr>
            <b-th>Dokument</b-th>
            <b-th>Predano</b-th>
            <b-th>Predaj/Preuzmi</b-th>
          </b-tr>
        </b-thead>
        <b-tbody>
          <b-tr>
            <b-td>Anketa</b-td>
            <b-td
              v-if="dokumenti.anketa === null"
              style="font-size: 3rem;"
              variant="danger"
            >
              <BIconXOctagon />
            </b-td>
            <b-td v-else style="font-size: 3rem;" variant="success"
              ><BIconCheckCircle
            /></b-td>

            <b-td style="font-size: 3 rem;">
              <div style="display:inline-block;width:90%;">
                <b-button
                  @click="anketaModal = true"
                  id="anketaButton"
                  class="mt-3"
                  :variant="dokumenti.anketa === null ? 'danger' : 'success'"
                >
                  <b-icon-text-center />
                </b-button>
              </div>
              <div style="display:inline-block;width:10%;height:100%;">
              </div>
              <b-tooltip
                v-if="dokumenti.anketa === null"
                target="anketaButton"
                triggers="hover"
              >
                Popuni anketu
              </b-tooltip>
              <b-tooltip v-else target="anketaButton" triggers="hover">
                Uredi anketu
              </b-tooltip>
            </b-td>
          </b-tr>
          <b-tr>
            <b-td>Dnevnik</b-td>
            <b-td
              v-if="dokumenti.dnevnik === null"
              style="font-size: 3rem;"
              variant="danger"
            >
              <BIconXOctagon />
            </b-td>
            <b-td v-else style="font-size: 3rem;" variant="success"
              ><BIconCheckCircle
            /></b-td>
            <b-td style="font-size: 3rem;">
              <div style="display:inline-block;width:90%">
              <b-button
                @click="uploadDnevnik"
                v-if="dokumenti.dnevnik === null"
                class="mr-3"
                variant="outline-primary"
              >
                <BIconUpload />
              </b-button>
              <b-button
                id="downloadDnevnik"
                @click="downloadDocument(dokumenti.dnevnik)"
                :style="
                  dokumenti.dnevnik === null ? 'cursor:not-allowed;' : null
                "
                :disabled="dokumenti.dnevnik === null"
                :variant="dokumenti.dnevnik === null ? 'danger' : 'success'"
              >
                <BIconDownload />
              </b-button>
                <b-tooltip target="downloadDnevnik" triggers="hover">
                  Preuzmi dnevnik
                </b-tooltip>
              </div>
              <div style="display:inline-block;width:10%;height:100%;">
                <b-button-close
                  @click="izbrisiDnevnik"
                  v-if="dokumenti.dnevnik !== null"
                  id="deleteDnevnik"
                />
                  <b-tooltip target="deleteDnevnik" triggers="hover">
                    Izbrisi dodani dnevnik
                  </b-tooltip>
              </div>

              
            </b-td>
          </b-tr>
          <b-tr>
            <b-td>Izvjesce</b-td>
            <b-td
              v-if="dokumenti.izvjesce === null"
              style="font-size: 3rem;"
              variant="danger"
            >
              <BIconXOctagon />
            </b-td>
            <b-td v-else style="font-size: 3rem;" variant="success"
              ><BIconCheckCircle
            /></b-td>
            <b-td style="font-size: 3rem;" class="text-center">
              <div style="display:inline-block;width:90%;">
              <b-button
                @click="uploadIzvjesce"
                v-if="dokumenti.izvjesce === null"
                class="mr-3"
                variant="outline-primary"
              >
                <BIconUpload />
              </b-button>
              <b-button
                id="downloadIzvjesce"
                @click="downloadDocument(dokumenti.izvjesce)"
                :style="
                  dokumenti.izvjesce === null ? 'cursor:not-allowed;' : null
                "
                :disabled="dokumenti.izvjesce === null"
                :variant="dokumenti.izvjesce === null ? 'danger' : 'success'"
              >
                <BIconDownload />
              </b-button>
              </div>

              <b-tooltip target="downloadIzvjesce" triggers="hover">
                Preuzmi izvjesce
              </b-tooltip>
              <div style="display:inline-block;width:10%;height:100%;">
                <b-button-close
                  @click="izbrisiIzvjesce"
                  id="deleteIzvjesce"
                  v-if="dokumenti.izvjesce !== null"
                />
              </div>
              <b-tooltip
                v-if="dokumenti.izvjesce !== null"
                target="deleteIzvjesce"
                triggers="hover"
              >
                Izbrisi dodano izvjesce
              </b-tooltip>
            </b-td>
            <!-- INPUT HIDDEN -->
            <input
              type="file"
              v-if="showIzvjesceFileInput"
              @change="izvjesceAdded"
              ref="izvjesceFileInput"
              style="display:none"
            />
            <input
              type="file"
              v-if="showDnevnikFileInput"
              @change="dnevnikAdded"
              ref="dnevnikFileInput"
              style="display:none"
            />
          </b-tr>
        </b-tbody>
        <b-tfoot>
          <b-tr>
            <b-td colspan="7" variant="secondary"> </b-td>
          </b-tr>
        </b-tfoot>
      </b-table-simple>
      <b-button 
      v-if="dokumenti.anketa !== null && dokumenti.izvjesce !== null && dokumenti.dnevnik !== null" 
      @click="generirajPrijavnicu" 
      variant="success" block>
        <div v-if="loadingPrijavnica" class="spinner-border" role="status">
        </div>
        <span v-if="!loadingPrijavnica">
          Generiraj PDF Prijavnicu
        </span>
        </b-button>
    </b-container>
    <Anketa
      :viewMode="false"
      v-if="anketaModal"
      :data="dokumenti.anketa"
      :model="anketaModal"
      @anketaPredana="anketaPredana"
      @updateAnketa="updateAnketa"
      @closeModal="anketaModal = false"
    />
  </div>
</template>

<script>
// @ is an alias to /src
import OsnovniPodaci from '@/components/OsnovniPodaci.vue';
import Anketa from '../components/Anketa.vue';

export default {
  name: 'home',
  components: {
    OsnovniPodaci,
    Anketa,
  },
  data() {
    return {
      showIzvjesceFileInput: true,
      showDnevnikFileInput: true,
      loadingPrijavnica: false,
      loadingPage: null,
      anketaModal: false,
      showForm: false,
      dokumenti: {
        anketa: null,
        izvjesce: null,
        dnevnik: null,
      },
    };
  },
  methods: {
    async generirajPrijavnicu() {
      this.loadingPrijavnica = true;
      await this.downloadDocument({fileUrl: 'api/graph/generatePrijavnicaUser'});
      this.loadingPrijavnica = false;
    },
    async updateAnketa(anketa) {
      if (!anketa.peto) {
        delete anketa.sesto;
      }
      try {
        const res = await this.$axios.post(
          'api/dokumenti/updateAnketa',
          anketa
        );
        this.dokumenti.anketa = res.data;
        this.anketaModal = false;
      } catch (e) {
        this.$bvToast.toast('Pogreska kod azuriranja ankete', {
            title: 'Error',
            autoHideDelay: 4000,
          });
      }
    },
    async anketaPredana(anketa) {
      if (!anketa.peto) {
        delete anketa.sesto;
      }
      try {
        const res = await this.$axios.post('api/dokumenti/setAnketa', anketa);
        this.dokumenti.anketa = res.data;
        this.anketaModal = false;
      } catch (e) {
        this.$bvToast.toast('Pogreska kod predavanja ankete', {
            title: 'Error',
            autoHideDelay: 4000,
          });
      }
    },
    async izbrisiDnevnik() {
      if(this.$refs.dnevnikFileInput.files.length !== 0) {
        this.showDnevnikFileInput = false;
        this.$nextTick(() => {
          this.showDnevnikFileInput = true;
        })
      }
      try {
        const res = await this.$axios.delete('api/dokumenti/deleteDnevnik');
        if (res.data === 1) {
          this.dokumenti.dnevnik = null;
          this.$bvToast.toast(
            'Uspjesno obrisan dnevnik',
            {
              title: 'Uspjesno',
              autoHideDelay: 4000,
            }
          );
        }
      } catch (e) {
        this.$bvToast.toast('Pogreska kod brisanja dnevnika', {
            title: 'Error',
            autoHideDelay: 4000,
          });
      }
    },
    async izbrisiIzvjesce() {
      if(this.$refs.izvjesceFileInput.files.length !== 0) {
        this.showIzvjesceFileInput = false;
        this.$nextTick(() => {
          this.showIzvjesceFileInput = true;
        })
      }
      try {
        const res = await this.$axios.delete('api/dokumenti/deleteIzvjesce');
        if (res.data === 1) {
          this.dokumenti.izvjesce = null;
          this.$bvToast.toast(
            'Uspjesno obrisano izvjesce',
            {
              title: 'Uspjesno',
              autoHideDelay: 4000,
            }
          );
        }
      } catch (e) {
        this.$bvToast.toast('Pogreska kod brisanja izvjesca', {
            title: 'Error',
            autoHideDelay: 4000,
          });
      }
    },
    async uploadIzvjesce() {
      this.$refs.izvjesceFileInput.click();
    },
    async uploadDnevnik() {
      this.$refs.dnevnikFileInput.click();
    },
    async izvjesceAdded(e) {
      if (e.target.files.length != 0) {
        const izvjesce = await this.uploadIzvjesceToServer(e.target.files[0]);
        if (izvjesce !== null) {
          this.dokumenti.izvjesce = izvjesce;
          this.$bvToast.toast(
            'Uspjesno dodano izvjesce',
            {
              title: 'Uspjesno',
              autoHideDelay: 4000,
            }
          );
        }
      }
    },
    async dnevnikAdded(e) {
      if (e.target.files.length != 0) {
        const dnevnik = await this.uploadDnevnikToServer(e.target.files[0]);
        if (dnevnik !== null) {
          this.dokumenti.dnevnik = dnevnik;
          this.$bvToast.toast(
            'Uspjesno dodan dnevnik',
            {
              title: 'Uspjesno',
              autoHideDelay: 4000,
            }
          );
        }
      }
    },
    async uploadIzvjesceToServer(file) {
      try {
        let formData = new FormData();
        formData.append('izvjesceFile', file);
        const response = await this.$axios.post(
          'api/dokumenti/setIzvjesce',
          formData,
          {
            headers: {
              'Content-Type': 'multipart/form-data',
            },
          }
        );
        const izvjesce = response.data;
        izvjesce.fileUrl = '/api/dokumenti/getIzvjesce';
        return izvjesce;
      } catch (e) {
        this.$bvToast.toast('Pogreska kod predavanja izvjesca', {
            title: 'Error',
            autoHideDelay: 4000,
          });
        return null;
      }
    },
    async uploadDnevnikToServer(file) {
      try {
        let formData = new FormData();
        formData.append('dnevnikFile', file);
        const response = await this.$axios.post(
          'api/dokumenti/setDnevnik',
          formData,
          {
            headers: {
              'Content-Type': 'multipart/form-data',
            },
          }
        );
        const dnevnik = response.data;
        dnevnik.fileUrl = '/api/dokumenti/getDnevnik';
        return dnevnik;
      } catch (e) {
        this.$bvToast.toast('Pogreska kod predavanja dnevnika', {
            title: 'Error',
            autoHideDelay: 4000,
          });
        return null;
      }
    },

    async downloadDocument(doc) {
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
    async submitData(formData) {
      this.loadingPage = true;
      try {
        const OsnovniPodaci = {
          IdUsera: localStorage.getItem('id'),
          Termin: null,
          Studij: formData.studij,
          Poduzece: formData.poduzece,
          NazivMentora: formData.nazivMentora,
        };
        await this.$axios.post(
          '/api/osnovniPodaci/setOsnovniPodaci',
          OsnovniPodaci
        );
        this.showForm = false;
        this.loadingPage = false;
      } catch (e) {
        this.$bvToast.toast('Pogreska kod predavanja osnovnih kodataka', {
            title: 'Error',
            autoHideDelay: 4000,
          });
      }
    },
    async getAllDocuments() {
      try {
        const res = await this.$axios.get('/api/dokumenti/getDocuments');
        const docs = res.data;
        if (docs.anketa !== null) {
          //todo
        }
        if (docs.dnevnik !== null) {
          docs.dnevnik.fileUrl = '/api/dokumenti/getDnevnik';
        }
        if (docs.izvjesce !== null) {
          docs.izvjesce.fileUrl = '/api/dokumenti/getIzvjesce';
        }
        return docs;
      } catch (e) {
        return {
          anketa: null,
          izvjesce: null,
          dnevnik: null,
        };
      }
    },
  },
  async created() {
    this.loadingPage = true;
    const id = localStorage.getItem('id');
    try {
      const res = await this.$axios.get(
        `/api/osnovniPodaci/getOsnovniPodaci/${id}`
      );
      if (res.status == 204) {
        this.showForm = true;
      } else {
        const docs = await this.getAllDocuments(this.$axios);
        this.dokumenti = docs;
      }
    } catch (e) {
      this.$bvToast.toast(
        `Pogreska kod dohvacanja dokumenata ${e.response.message}`,
        {
          title: 'Pogreska',
          autoHideDelay: 4000,
        }
      );
    }
    this.loadingPage = false;
  },
};
</script>
