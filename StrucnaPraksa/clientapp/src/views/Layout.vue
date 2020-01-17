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
        <b-navbar-nav class="ml-auto" v-if="!logedInUser">
          <b-button @click="openRegisterDialog" variant="outline-danger">Register</b-button>
          <b-button @click="openLoginDialog" variant="outline-primary">Login</b-button>
        </b-navbar-nav>
        <b-navbar-nav class="ml-auto" v-else>
            <b-row>
              <b-col>
                {{logedInUser}}
              </b-col>
              <b-col>
                <b-button @click="logout" variant="danger">Logout</b-button>
              </b-col>
            </b-row>
        </b-navbar-nav>
      </b-navbar>
    <b-container>
      <router-view/>
    </b-container>
    <!-- LOGIN -->
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
      <!-- REGISTER -->
      <b-modal title="Register" v-model="registerDialog" id="registerModal">
        <b-form-input type="text" placeholder="Username" v-model="username"/>
        <b-form-input type="password" placeholder="Password" v-model="password"/>
        <template v-slot:modal-footer>
          <b-button variant="primary" @click = "register" >
            Register
            <b-spinner style="width: 1rem; height: 1rem;" v-if="registerLoading"/>
          </b-button>
          <b-button variant="danger" @click="registerDialog = false; username = ''; password = ''">
            Cancel
          </b-button>
        </template>
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
        registerLoading: false,
        username: '',
        password: '',
        logedInUser: null,
      }
    },
    mounted() {
      if(this.logedInUser === null) {
        const user = localStorage.getItem('user');
        if(user !== null) {
          this.logedInUser = user;
        }
      }
    },
    methods: {
      logout() {
        this.logedInUser = '';
        localStorage.removeItem('token');
        localStorage.removeItem('ADMIN');
        localStorage.removeItem('user');
      },
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
          localStorage.setItem('user', res.user);
          this.logedInUser = res.user;
          this.username = '';
          this.password = '';
          this.loginLoading = false;
          this.loginDialog = false;
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
        this.loginLoading = false;
      },
      register() {
        this.registerLoading = true;
        const res = mockBackend.register(this.username, this.password);
        console.log(mockBackend.getAllUsers());
        if (res) {
          this.$bvToast.toast("Uspjesno registriran korisnik", {
            title: 'Uspjesno',
            autoHideDelay: 4000,
          });
        }
        console.log('register', res);
      }
    }
}
</script>

<style lang="scss" scoped>

</style>