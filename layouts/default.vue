<template>
  <v-app dark>
    <v-navigation-drawer v-model="drawer" :mini-variant="miniVariant" :clipped="clipped" fixed app color="primary" dark
      temporary>
      <v-list dense>
        <v-list-item v-for="(item, i) in items" :key="i" :to="item.to" router exact>
          <v-list-item-action>
            <v-icon>{{ item.icon }}</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>{{ item.title }}</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>


    <v-app-bar :clipped-left="clipped" fixed app color="indigo darken-1" dark>
      <v-app-bar-nav-icon @click.stop="drawer = !drawer" />
      <v-toolbar-title>{{ title }}</v-toolbar-title>
      <v-spacer />
      <v-btn icon @click.stop="rightDrawer = !rightDrawer">
      </v-btn>
    </v-app-bar>

    <v-main>
      <v-container fluid>
        <Nuxt />
      </v-container>
    </v-main>

    <v-footer :absolute="!fixed" app color="indigo darken-4" dark>
      <v-spacer />
      <span>&copy; {{ new Date().getFullYear() }} - Carol Pontara</span>
    </v-footer>
  </v-app>
</template>

<script>
export default {
  data() {
    return {
      clipped: false,
      drawer: false,
      fixed: true,
      miniVariant: false,
      rightDrawer: true,
      title: 'Sistema de Gerenciamento',
      items: [
        {
          icon: 'mdi-home',
          title: 'Home',
          to: '/',
        },
        {
          icon: 'mdi-warehouse',
          title: 'Equipamentos',
          to: '/equipamentos',
        },
        {
          icon: 'mdi-tools',
          title: 'Manutenções',
          to: '/manutencoes',
        },
        {
          icon: 'mdi-monitor',
          title: 'Técnicos',
          to: '/tecnicos',
        },
        {
          icon: 'mdi-checkbox-multiple-blank-outline',
          title: 'Histórico',
          to: '/historico',
        },
      ],
    };
  },
};

</script>

<style scoped>
.v-toolbar-title {
  font-weight: bold;
  letter-spacing: 1px;
}

.v-main {
  min-height: 100vh;
}

.v-footer {
  padding: 10px 20px;
  font-size: 0.9em;
}

.v-btn {
  width: 200px;
  height: 50px;
  font-size: 16px;
  text-transform: none;
  padding: 0;
  display: flex;
  justify-content: center;
  align-items: center;
  border-radius: 5px;
  margin: 5px;
}
</style>
