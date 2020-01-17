<template>
  <div>
    <b-navbar toggleable="sm" type="light" sticky variant="light">
        <b-navbar-toggle target="nav-text-collapse"></b-navbar-toggle>
        <b-navbar-brand>Strucna praksa</b-navbar-brand>
        <b-collapse id="nav-text-collapse" is-nav>
          <b-row>
              <b-button variant="outline-primary">Pregled</b-button>
              <b-button variant="outline-primary">Pregled</b-button>
          </b-row>
        </b-collapse>
        <b-navbar-nav class="ml-auto">
          <b-button @click="openRegisterDialog" variant="outline-danger">Register</b-button>
          <b-button @click="openLoginDialog" variant="outline-primary">Login</b-button>
        </b-navbar-nav>
      </b-navbar>
    <b-container>
      <router-view/>
    </b-container>
      <b-modal title="Login" v-model="loginDialog" id="loginModal">
        <b-form-input type="text" placeholder="Username" v-model="username"/>
        <b-form-input type="password" placeholder="Password" v-model="password"/>
        <template v-slot:modal-footer>
          <b-button variant="primary" @click = "login" >
            Login
            <b-spinner style="width: 1rem; height: 1rem;" v-if="loginLoading"/>
          </b-button>
          <b-button variant="danger" @click="loginDialog = false; username = ''; password = ''">
            Cancel
          </b-button>
        </template>
      </b-modal>
      <b-modal v-model="registerDialog" id="registerModal">
        username
        pw
      </b-modal>
  </div>
</template>

<script>
import mockBackend from '../mockBackend';

export default {
    data() {
      return {
        loginDialog: false,
        registerDialog: false,
        loginLoading: false,
        username: '',
        password: '',
      }
    },
    methods: {
      openLoginDialog() {
        this.loginDialog = true;
      },
      openRegisterDialog() {
        this.registerDialog = true;
      },
      login() {
        this.loginLoading = true;
        const res = mockBackend.login(this.username, this.password);
        if (res) {
          localStorage.setItem('token', res.token);
          localStorage.setItem('ADMIN', res.admin);
        }
        else {
          this.username = '';
          this.password = '';
          this.loginLoading = false;
          this.$bvToast.toast("Pogresan login", {
            title: 'Error',
            autoHideDelay: 4000,
          });
        }
        console.log('login', res);
      },
      register() {
        console.log('register');
      }
    }
}
</script>

<style lang="scss" scoped>

</style>