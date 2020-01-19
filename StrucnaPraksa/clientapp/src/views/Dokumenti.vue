<template>
  <div class="dokumenti">
    test
    <b-container>
      <b-table-lite :items="tableItems">
      </b-table-lite>
    </b-container>
  </div>
</template>

<script>
// @ is an alias to /src

export default {
  name: 'home',
  data() {
    return {
      tableItems: [
        {
          id:1,
          name: "test",
        },
        {
          id:2,
          name: "test1",
        }
      ],
    }
  },
  mounted () {
    // get current user documents, if there is no Praksa-year document, 
    // ask to register for praksa this year
  },
}
</script>
