<template>
  <b-modal
    header-bg-variant="success"
    size="lg"
    title="Anketa"
    v-model="modelAnketa"
    id="anketaModal"
  >
    <!-- FORMA -->
    <b-form>
      <b-form-group
        :state="isOneTo10(anketa.prvo, 'anketaPrvo')"
        invalid-feedback="Odaberite ocjenu"
      >
        <template v-slot:label>
          <span>
            1. Koliko ste zadovoljni našim studentima na praksi?
            <br />
            Ocijenite ocjenom od 1 do 10.
          </span>
        </template>
        <b-form-rating
          id="anketaPrvo"
          show-value
          :readonly="viewMode"
          v-model="anketa.prvo"
          stars="10"
        />
      </b-form-group>
      <b-form-group
        :state="isOneTo10(anketa.drugo, 'anketaDrugo')"
        invalid-feedback="Odaberite ocjenu"
      >
        <template v-slot:label>
          <span>
            2. Ocijenite znanje i kompetencije studenata na praksi.
            <br />
            Ocijenite ocjenom od 1 do 10.
          </span>
        </template>
        <b-form-rating
          :readonly="viewMode"
          id="anketaDrugo"
          show-value
          v-model="anketa.drugo"
          stars="10"
        ></b-form-rating>
      </b-form-group>

      <b-form-group
        id="anketaTreceFormGroup"
        :state="isNotEmpty(anketa.trece, 'anketaTrece')"
        invalid-feedback="Obavezno polje"
        label="3. Koje područje znanja (kompetencije) bi po vašem mišljenju trebalo nadopuniti?"
        label-for="anketaTrece"
      >
        <b-form-textarea
          :readonly="viewMode"
          id="anketaTrece"
          v-model="anketa.trece"
          rows="3"
          max-rows="6"
        ></b-form-textarea>
      </b-form-group>

      <b-form-group
        :state="isOneTo10(anketa.cetvrto, 'anketaCetvrto')"
        invalid-feedback="Odaberite ocjenu"
      >
        <template v-slot:label>
          <span>
            4. Ocijenite opravdanost (važnost) stručnog studija na Međimurskom
            veleučilištu u Čakovcu?
            <br />
            Ocijenite ocjenom od 1 do 10.
          </span>
        </template>
        <b-form-rating
          :readonly="viewMode"
          id="anketaCetvrto"
          show-value
          v-model="anketa.cetvrto"
          stars="10"
        ></b-form-rating>
      </b-form-group>

      <b-form-group
        :state="isNotEmpty(anketa.peto, 'anketaPeto')"
        invalid-feedback="Obavezno polje"
      >
        <template v-slot:label>
          <span>
            5. Smatrate li da treba povećati udio prakse kroz studij?
          </span>
        </template>
        <b-form-radio-group
          :readonly="viewMode"
          v-model="anketa.peto"
          :options="[
            {
              text: 'Da',
              value: 'Da',
            },
            {
              text: 'Ne',
              value: 'Ne',
            },
          ]"
          name="radioPeto"
        ></b-form-radio-group>
      </b-form-group>
      <b-form-group
        label="6. Ako je odgovor potvrdan, navedite omjer praksa/teorija?"
        v-if="anketa.peto === 'Da'"
      >
        <b-form-input
          :readonly="viewMode"
          id="range-1"
          autofocus
          v-model="anketa.sesto"
          type="range"
          min="0"
          max="100"
        >
        </b-form-input>
        <span class="float-right">{{ omjer }}</span>
      </b-form-group>
      <b-form-group
        :state="isNotEmpty(anketa.sedmo, 'anketaSedmo')"
        invalid-feedback="Obavezno polje"
        label="7. Da li ste spremni prihvatiti studente na praksu u dužem razdoblju od trenutačno planirane?"
      >
        <b-form-radio-group
          :readonly="viewMode"
          v-model="anketa.sedmo"
          :options="[
            {
              text: 'Da',
              value: 'Da',
            },
            {
              text: 'Ne',
              value: 'Ne',
            },
          ]"
          name="radioSedmo"
        ></b-form-radio-group>
      </b-form-group>
      <b-form-group
        v-if="anketa.sedmo === 'Da'"
        label="Ako je odgovor potvrdan, molimo vas da navedete svoj prijedlog."
        :state="isNotEmpty(anketa.sedmoKomentar, 'anketaSedmoKomentar')"
        invalid-feedback="Molimo upisite svoj prijedlog"
      >
        <b-form-input
          :readonly="viewMode"
          id="sedmoKomentar"
          v-model="anketa.sedmoKomentar"
          type="text"
        ></b-form-input>
      </b-form-group>
      <b-form-group
        :state="isNotEmpty(anketa.osmo, 'anketaOsmo')"
        invalid-feedback="Obavezno polje"
        label="8. Prema vašem mišljenju kojih kadrova nedostaje na tržištu?"
        label-for="anketaOsmo"
      >
        <b-form-textarea
          :readonly="viewMode"
          id="anketaOsmo"
          v-model="anketa.osmo"
          rows="3"
          max-rows="6"
        ></b-form-textarea>
      </b-form-group>

      <b-form-group
        :state="isNotEmpty(anketa.deveto, 'anketaDeveto')"
        invalid-feedback="Obavezno polje"
        label="9. Prema vašem mišljenju kojim nastavnim predmetima treba povećati fond da bi praksa bila uspješnija?"
        label-for="anketaDeveto"
      >
        <b-form-textarea
          :readonly="viewMode"
          id="anketaDeveto"
          v-model="anketa.deveto"
          rows="3"
          max-rows="6"
        ></b-form-textarea>
      </b-form-group>
      <b-form-group
        :state="isNotEmpty(anketa.deseto, 'anketaDeseto')"
        invalid-feedback="Obavezno polje"
        label="10. Kako vidite gospodarstvo i naše studente za nekoliko godina?"
      >
        <b-form-select
          :disabled="viewMode"
          v-model="anketa.deseto"
          :options="desetoOptions"
        ></b-form-select>
      </b-form-group>
      <b-form-group
        :state="isNotEmpty(anketa.desetoKomentar, 'anketaDesetoKomentar')"
        invalid-feedback="Molimo upisite vase misljenje"
        v-if="anketa.deseto === 'd'"
      >
        <b-form-textarea
          :readonly="viewMode"
          id="anketaDesetoKomentar"
          v-model="anketa.desetoKomentar"
          rows="3"
          max-rows="6"
        ></b-form-textarea>
      </b-form-group>

      <b-form-group
        :state="isNotEmpty(anketa.jedanaesto, 'anketaJedanaesto')"
        invalid-feedback="Obavezno polje"
        label="11. Molimo vaš prijedlog prakse studenata za potrebe vašeg gospodarskog subjekta ili institucije"
      >
        <b-form-textarea
          :readonly="viewMode"
          id="anketaJedanaesto"
          v-model="anketa.jedanaesto"
          rows="3"
          max-rows="6"
        ></b-form-textarea>
      </b-form-group>

      <b-form-group
        :state="isNotEmpty(anketa.dvanaesto, 'anketaDvanaesto')"
        invalid-feedback="Obavezno polje"
        label="12. Vaš prijedlog kako bismo mogli pomoći studentima u njihovim kompetencijama"
      >
        <b-form-textarea
          :readonly="viewMode"
          id="anketaDvanaesto"
          v-model="anketa.dvanaesto"
          rows="3"
          max-rows="6"
        ></b-form-textarea>
      </b-form-group>
    </b-form>
    <!-- /FORMA -->
    <template v-slot:modal-footer>
      <b-button @click="abortChange">
        Odustani
      </b-button>
      <b-button v-if="!viewMode" @click="sendAnketa" variant="success">
        OK
      </b-button>
    </template>
  </b-modal>
</template>

<script>
let validationErrors = [];
export default {
  data() {
    return {
      desetoOptions: [
        { value: null, text: 'Please select an option' },
        {
          value: 'a',
          text:
            'Gospodarstvo RH će se morati prilagoditi zahtjevima tržišta EU',
        },
        {
          value: 'b',
          text:
            'Studenti uz cjeloživotno obrazovanje bit će podrška našem gospodarstvu',
        },
        {
          value: 'c',
          text:
            'Gospodarstvo i obrazovanje treba uskladiti sa stvarnim potrebama',
        },
        { value: 'd', text: 'vaše mišljenje' },
      ],
      isEdit: false,
      anketa: {
        sesto: '50',
      },
    };
  },
  props: ['model', 'data', 'viewMode'],
  computed: {
    omjer() {
      return `Praksa: ${this.anketa.sesto} Teorija: ${100 - this.anketa.sesto}`;
    },
    modelAnketa: {
      set: function(newValue) {
        if (!newValue) this.$emit('closeModal');
      },
      get: function() {
        return this.model;
      },
    },
  },
  methods: {
    abortChange() {
      this.$emit('closeModal');
    },
    sendAnketa() {
      if (validationErrors.length !== 0) {
        this.$bvToast.toast(
          'Postoje validacijske greske, molimo ispravite odgovore',
          {
            title: 'Pogreska',
            variant: 'danger',
            autoHideDelay: 4000,
          }
        );
      } else {
        if (!this.isEdit) {
          this.$emit('anketaPredana', this.anketa);
        } else {
          this.$emit('updateAnketa', this.anketa);
        }
      }
    },
    //validations
    isOneTo10(data, location) {
      if (
        typeof data === 'undefined' ||
        data === null ||
        data < 1 ||
        data > 10
      ) {
        if (!validationErrors.includes(location)) {
          validationErrors.push(location);
        }
        return false;
      } else {
        if (validationErrors.includes(location)) {
          const index = validationErrors.indexOf(location);
          validationErrors.splice(index, 1);
        }
        return true;
      }
    },
    isNotEmpty(data, location) {
      if (typeof data === 'undefined' || data === null || data.length < 1) {
        if (!validationErrors.includes(location)) {
          validationErrors.push(location);
        }
        return false;
      } else {
        if (validationErrors.includes(location)) {
          const index = validationErrors.indexOf(location);
          validationErrors.splice(index, 1);
        }
        return true;
      }
    },
  },
  mounted() {
    if (this.data) {
      this.isEdit = true;
      this.anketa = this.data;
    }
  },
  beforeDestroy() {
    validationErrors = [];
  },
};
</script>

<style scoped></style>
