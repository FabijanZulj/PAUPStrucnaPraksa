<template>
  <b-row>
    <b-col cols="3">
      <b-form-group label="Odaberite pitanje u anketi za koje zelite prikaz grafa:">
        <b-form-select @change="questionChanged" v-model="selectedQuestion" :options="questionOptions"></b-form-select>
      </b-form-group>
      <b-form-group label="Odaberite tip grafa:">
        <b-form-select @change="chartTypeChanged" :value="chartType" :options="chartTypes"></b-form-select>
      </b-form-group>
    </b-col>
    <b-col>
      <apexchart v-if="!loadingChart" disable class="m" width="708" :type="chartType" :options="chartOptions" :series="series"></apexchart>
    </b-col>
  </b-row>
</template>

<script>

export default {

  data() {
    return {
      allQuestionData: null,
      loadingChart: false,
      selectedQuestion: 'prvoPitanje',
      chartType: 'bar',
      chartTypes: [
        { value: 'bar', text: 'Bar' },
        { value: 'pie', text: 'Pie' }
      ],
      questionOptions: [
        {value: null, text: 'Molimo odaberite pitanje'},
        {value: 'prvoPitanje', text:'Pitanje 1.'},
        {value: 'drugoPitanje', text:'Pitanje 2.'},
        {value: 'cetvrtoPitanje', text:'Pitanje 4.'},
        {value: 'petoPitanje', text:'Pitanje 5.'},
        {value: 'sedmoPitanje', text:'Pitanje 7.'},
        {value: 'desetoPitanje', text:'Pitanje 10.'},
      ],
      questionData: {
        jedan:10,
        dva:14,
        tri:17,
        cetiri:18,
        pet:19,
        sest:10,
        sedam: 2,
        osam:4,
        devet:13,
        deset:45
      },
      chartOptions: {
          chart: {
            id: 'Anketa graf'
          },
          xaxis: {
            categories: []
          }
        },
        series: [{
          name: 'Broj ocjena',
          data: []
        }]
    }
  },
  async created() {
    try {
      const date = new Date();
      const res = await this.$axios.get(`api/graph/getGraphData?godina=${date.getFullYear()}`);
      this.allQuestionData = res.data;
      const values = [];
      let pitanje = '';
      Object.keys(this.allQuestionData.prvoPitanje).forEach((label) => {
        if(label !== 'pitanje') {
          values.push(label[0].toUpperCase() + label.slice(1));
          this.series[0].data.push(this.allQuestionData.prvoPitanje[label]);
        } else {
          pitanje = this.allQuestionData.prvoPitanje[label]
        }
      });
      this.chartOptions = {
        title: {
          text: pitanje,
        },
        chart: {
            id: 'Anketa graf'
        },
        xaxis: {
            categories: values
          }
      }
    } catch(e) {
      this.$bvToast.toast('Pogreska kod dohvacanja grafova', {
            title: 'Error',
            autoHideDelay: 4000,
          });
    }
  },
  methods:{
    questionChanged(question) {
      if(this.chartType ==='bar') {
        const values = [];
        let pitanje = '';
        this.series[0].data=[];
        Object.keys(this.allQuestionData[question]).forEach((label) => {
          if(label !== 'pitanje') {
            values.push(label[0].toUpperCase() + label.slice(1));
            this.series[0].data.push(this.allQuestionData[question][label]);
          } else {
            pitanje = this.allQuestionData[question][label];
          }
        });
        this.chartOptions = {
          title: {
            text: pitanje
          },
          chart: {
              id: 'Anketa graf'
          },
          xaxis: {
              categories: values
            }
        }
      } else {
        const newLabels = [];
        const newSeries = [];
        let pitanje = '';
        Object.keys(this.allQuestionData[question]).forEach((label) => {
          if(label !== 'pitanje') {
            newSeries.push(this.allQuestionData[question][label]);
            newLabels.push(label[0].toUpperCase() + label.slice(1));
          } else {
            pitanje = this.allQuestionData[question][label];
          }
        });
        this.series = newSeries;
        this.chartOptions = {
          title: {
            text:pitanje
          },
          chart: {
              id: 'Anketa graf'
          },
          labels: newLabels, 
        }
      }
    },
    async chartTypeChanged(type) {
      this.loadingChart = true;
      if(type === 'pie'){
        const oldChartOptions = Object.assign({}, this.chartOptions);
        const oldSeries = Object.assign({}, this.series);
        this.series = oldSeries[0].data;
        this.chartOptions = {
          title: oldChartOptions.title,
          chart: {
              id: 'Anketa graf'
          },
          labels: oldChartOptions.xaxis.categories, 
        };
      } else {
        const oldChartOptions = Object.assign({}, this.chartOptions);
        const oldSeries = this.series.slice();
        this.series = [{
          name: 'Broj ocjena',
          data: oldSeries
        }]
        this.chartOptions = {
          title: oldChartOptions.title,
          chart: {
            id: 'Anketa graf'
          },
          xaxis: {
            categories: oldChartOptions.labels
          }
        }
      }
      this.chartType = type;
      await this.$nextTick();
      this.loadingChart= false;
    },
    changeData() {
      this.series[0].data.push(20);
      // this.$set(this.chartOptions.xaxis,'categoeis',this.chartOptions.xaxis.categories.push('DODANI'));
      this.chartOptions = Object.assign({},this.chartOptions,this.chartOptions.xaxis.categories.push('DODANI'));
    }
  }
}
</script>

<style>

</style>