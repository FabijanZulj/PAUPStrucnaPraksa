<template>
  <div style="width:80%" class="container">
    <b-navbar
      style="border-bottom-left-radius:30px;border-bottom-right-radius:30px; background-color:#4ac1ae;"
      id="nav"
      toggleable="sm"
      type="dark"
      sticky
    >
      <b-navbar-toggle target="nav-text-collapse"></b-navbar-toggle>
      <b-navbar-brand>
        Strucna praksa
      </b-navbar-brand>
      <b-collapse id="nav-text-collapse" is-nav>
        <b-navbar-nav>
          <b-nav-item class="button" />
          <b-nav-item>
            <b-button
              class="mr-1 float-right hoverable"
              @click="routerPush('/')"
              style="background-color:#4ac1ae"
            >
              <b>
                Pregled
              </b>
            </b-button>
          </b-nav-item>
          <b-nav-item>
            <b-button
              class="mr-1 float-right hoverable"
              @click="routerPush('dokumenti')"
              v-if="logedInUser"
              style="background-color:#4ac1ae"
            >
              <b>
                Dokumenti
              </b>
            </b-button>
          </b-nav-item>
          <b-dropdown
            v-if="isAdmin && logedInUser !== null"
            class="float-right"
            variant="success"
            id="dropdown-1"
            text="Admin"
          >
            <b-dropdown-item-button @click="routerPush('adminPregled')">
              Admin pregled
            </b-dropdown-item-button>
            <b-dropdown-item-button @click="routerPush('adminGraf')">
              Admin grafovi
            </b-dropdown-item-button>
            <b-dropdown-divider></b-dropdown-divider>
          </b-dropdown>
        </b-navbar-nav>
      </b-collapse>
      <b-navbar-nav class="ml-auto" v-if="!logedInUser">
        <b-nav-item>
          <b-button
            pill
            class="mr-1"
            @click="openRegisterDialog"
            variant="danger"
            >Register</b-button
          >
        </b-nav-item>
        <b-button pill @click="openLoginDialog" variant="success"
          >Login</b-button
        >
      </b-navbar-nav>
      <b-navbar-nav class="ml-auto" v-else>
        <b-nav-text>
          <span class="mr-3">
            <b> {{ logedInUser.ime }} {{ logedInUser.prezime }} </b>
          </span>
          <b-button @click="logout" variant="danger">Logout</b-button>
        </b-nav-text>
      </b-navbar-nav>
    </b-navbar>
    <!-- ROUTER VIEW -->
    <b-container>
      <router-view class="pt-5" />
    </b-container>
    <!--/ ROUTER VIEW -->

    <!-- LOGIN -->
    <b-modal
      title="Login"
      v-model="loginDialog"
      id="loginModal"
      @hide="
        username = '';
        password = '';
      "
    >
      <b-form id="loginForm" @submit.prevent="login">
        <label for="usernameLogin">Korisnicko ime</label>
        <b-form-input
          id="usernameLogin"
          :state="usernameState"
          class="mb-3"
          aria-describedby="login-username-feedback"
          type="text"
          placeholder="Username"
          v-model="username"
        />

        <label for="passwordLogin">Lozinka</label>
        <b-form-input
          id="passwordLogin"
          type="password"
          placeholder="Password"
          v-model="password"
        />
      </b-form>
      <template v-slot:modal-footer>
        <b-button form="loginForm" variant="primary" type="submit">
          Login
          <b-spinner style="width: 1rem; height: 1rem;" v-if="loginLoading" />
        </b-button>
        <b-button
          variant="danger"
          @click="
            loginDialog = false;
            username = '';
            password = '';
          "
        >
          Cancel
        </b-button>
      </template>
    </b-modal>
    <!-- REGISTER -->
    <b-modal
      title="Registriraj se"
      v-model="registerDialog"
      id="registerModal"
      @hide="
        username = '';
        password = '';
      "
    >
      <b-form id="registerForm" @submit.prevent="register">
        <label for="usernameRegister">Korisnicko ime:</label>
        <b-form-input
          id="usernameRegister"
          :state="usernameState"
          class="mb-3"
          type="text"
          placeholder="Username"
          aria-describedby="input-username-feedback"
          v-model="username"
        />
        <b-form-invalid-feedback id="input-username-feedback">
          Korisnicko ime mora biti duze od 5 znakova
        </b-form-invalid-feedback>

        <label for="passwordRegister">Lozinka</label>
        <b-form-input
          id="passwordRegister"
          :state="passwordState"
          type="password"
          aria-describedby="input-password-feedback"
          placeholder="Lozinka"
          v-model="password"
        />
        <b-form-invalid-feedback id="input-password-feedback">
          Lozinka se mora sastojato od vise od 5 znakova
        </b-form-invalid-feedback>

        <label for="imeRegister">Ime</label>
        <b-form-input
          id="imeRegister"
          :state="imeState"
          class="mb-3"
          type="text"
          placeholder="Ime"
          aria-describedby="input-ime-feedback"
          v-model="ime"
        />
        <b-form-invalid-feedback id="input-ime-feedback">
          Ime ne smije biti prazno
        </b-form-invalid-feedback>

        <label for="imeRegister">Prezime</label>
        <b-form-input
          id="prezimeRegister"
          :state="prezimeState"
          class="mb-3"
          type="text"
          placeholder="Prezime"
          aria-describedby="input-prezime-feedback"
          v-model="prezime"
        />
        <b-form-invalid-feedback id="input-prezime-feedback">
          Ime ne smije biti prazno
        </b-form-invalid-feedback>
      </b-form>

      <template v-slot:modal-footer>
        <b-button form="registerForm" type="submit" variant="primary">
          Register
          <b-spinner
            style="width: 1rem; height: 1rem;"
            v-if="registerLoading"
          />
        </b-button>
        <b-button
          variant="danger"
          @click="
            registerDialog = false;
            username = '';
            password = '';
          "
        >
          Cancel
        </b-button>
      </template>
    </b-modal>
  </div>
</template>

<script>
export default {
  data() {
    return {
      ime: '',
      prezime: '',
      isAdmin: false,
      loginDialog: false,
      registerDialog: false,
      loginLoading: false,
      registerLoading: false,
      username: '',
      password: '',
      logedInUser: null,
    };
  },
  computed: {
    usernameState() {
      return this.username.length > 5 ? true : false;
    },
    passwordState() {
      return this.password.length > 5 ? true : false;
    },
    imeState() {
      return this.ime.length > 0 ? true : false;
    },
    prezimeState() {
      return this.prezime.length > 0 ? true : false;
    },
  },
  mounted() {
    if (localStorage.getItem('ADMIN') === 'Admin') {
      this.isAdmin = true;
    }
    this.$axios.interceptors.response.use(
      (response) => {
        return response;
      },
      (error) => {
        if (401 === error.response.status) {
          this.$bvToast.toast('Sesija je istekla.', {
            title: 'Pogreska',
            autoHideDelay: 4000,
          });
          this.logout();
          this.routerPush('/');
          this.$router.go(1);
          return Promise.reject(error);
        } else {
          return Promise.reject(error);
        }
      }
    );
    if (this.logedInUser === null) {
      const user = localStorage.getItem('user');
      if (user !== null) {
        this.logedInUser = JSON.parse(user);
      }
    }
  },
  methods: {
    routerPush(location) {
      this.$router.push(location).catch(() => {});
    },
    logout() {
      this.logedInUser = null;
      localStorage.removeItem('token');
      localStorage.removeItem('ADMIN');
      localStorage.removeItem('user');
      localStorage.removeItem('id');
      this.routerPush('/');
    },
    openLoginDialog() {
      this.loginDialog = true;
    },
    openRegisterDialog() {
      this.registerDialog = true;
    },
    async login() {
      if (!this.usernameState) {
        return;
      }
      this.loginLoading = true;
      try {
        const res = await this.$axios.post('/api/login/authenticate', {
          Username: this.username,
          Password: this.password,
        });
        if (res.status === 200) {
          localStorage.setItem('token', res.data.token);
          localStorage.setItem('id', res.data.id);
          localStorage.setItem('ADMIN', res.data.role);
          localStorage.setItem('user', JSON.stringify(res.data));
          this.isAdmin = res.data.role === 'Admin' ? true : false;
          this.logedInUser = res.data;
          this.username = '';
          this.password = '';
          this.loginLoading = false;
          this.loginDialog = false;
        }
        this.loginLoading = false;
      } catch (e) {
        this.username = '';
        this.password = '';
        this.loginLoading = false;
        if (e.response === undefined) {
          this.$bvToast.toast('Pogreska kod spajanja na server', {
            title: 'Error',
            autoHideDelay: 4000,
          });
        } else {
          this.$bvToast.toast(e.response.data.message, {
            title: 'Error',
            autoHideDelay: 4000,
          });
        }
      }
    },
    async register() {
      if (!this.usernameState || !this.password) {
        return;
      }
      this.registerLoading = true;
      try {
        const res = await this.$axios.post('/api/login/register', {
          Username: this.username,
          Password: this.password,
          Ime: this.ime,
          Prezime: this.prezime,
        });
        if (res.status === 200) {
          this.registerLoading = false;
          this.username = '';
          this.password = '';
          this.ime = '';
          this.prezime = '';
          this.$bvToast.toast('Uspjesno registriran korisnik', {
            title: 'Uspjesno',
            autoHideDelay: 4000,
          });
          this.registerDialog = false;
        } else {
          this.registerLoading = false;
          this.username = '';
          this.password = '';
          this.ime = '';
          this.prezime = '';
          this.$bvToast.toast('Pogreska kod registriranja', {
            title: 'Pogreska',
            autoHideDelay: 4000,
          });
        }
      } catch (e) {
        this.registerLoading = false;
        this.username = '';
        this.password = '';
        this.ime = '';
        this.prezime = '';
        if (typeof e.response.data.message == 'undefined') {
          this.$bvToast.toast('Pogreska kod spajanja na server', {
            title: 'Error',
            autoHideDelay: 4000,
          });
        } else {
          this.$bvToast.toast(e.response.data.message, {
            title: 'Pogreska',
            autoHideDelay: 4000,
          });
        }
      }
    },
  },
};
</script>

<style lang="scss" scoped>
.hoverable:hover {
  background-color: #28a745 !important;
  transition-duration: 0.6s;
}
</style>
