<template>
  <div>
    <b-card class="mt-3" :header="`Osnovni podaci ${akGodina}`">
      <b-form @submit="onSubmit" v-if="show">
        <b-form-group
          id="input-group-1"
          label="Poduzece:"
          required
          label-for="input-1"
          description="Ime poduzeca u kojem ce se obavljati strucna praksa"
        >
          <b-form-input
            id="input-1"
            v-model="form.poduzece"
            required
            placeholder="Poduzece"
          ></b-form-input>
        </b-form-group>

        <b-form-group
          id="input-group-3"
          label="Naziv mentora:"
          label-for="input-3"
        >
          <b-form-input
            id="input-2"
            v-model="form.nazivMentora"
            required
            placeholder="Naziv mentora"
          ></b-form-input>
        </b-form-group>

        <b-form-group
          id="input-group-3"
          label="Naziv smjera:"
          label-for="input-3"
        >
          <b-form-input
            id="input-2"
            v-model="form.studij"
            required
            placeholder="Naziv studija/smjera"
          ></b-form-input>
        </b-form-group>

        <b-button type="submit" variant="primary">Prijava</b-button>
      </b-form>
    </b-card>
  </div>
</template>

<script>
export default {
  data() {
    return {
      form: {
        poduzece: '',
        nazivMentora: '',
        studij: ''
      },
      show: true,
      godina: new Date(),
    };
  },
  computed: {
    akGodina() {
      return `${this.godina.getFullYear() - 1}/${this.godina.getFullYear()}`;
    },
  },
  methods: {
    onSubmit(evt) {
      evt.preventDefault();
      this.$emit('submit', this.form);
    },
  },
};
</script>

<style></style>
