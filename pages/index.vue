<template>
  <v-app>
    <v-container>
      <v-row justify="center" class="mt-10">
        <v-col cols="12" md="8" class="text-center">
          <h1 class="text-h3 font-weight-bold">ZDz Portal de Manutenções</h1>
          <p class="text-subtitle-1">Gerencie seus equipamentos, manutenções e históricos com facilidade.</p>
        </v-col>
      </v-row>

      <v-row class="mt-5" justify="space-between" dense>
        <v-col cols="12" sm="3" md="3">
          <v-card class="pa-4 hoverable">
            <v-icon class="mb-2" color="indigo" size="40">mdi-plus-box</v-icon>
            <h2 class="text-h5 font-weight-bold">Cadastro de Equipamentos</h2>
            <p>Adicione novos equipamentos que chegarem na ZDz com organização.</p>
            <v-btn color="indigo" block outlined @click="$router.push('/equipamentos')">
              Acessar
            </v-btn>
          </v-card>
        </v-col>

        <v-col cols="12" sm="3" md="3">
          <v-card class="pa-4 hoverable">
            <v-icon class="mb-2" color="teal" size="40">mdi-tools</v-icon>
            <h2 class="text-h5 font-weight-bold">Cadastro de Manutenções</h2>
            <p>Registre manutenções e custos associados.
              Cadastro Simples!
            </p>
            <v-btn color="teal" block outlined @click="$router.push('/manutencoes')">
              Acessar
            </v-btn>
          </v-card>
        </v-col>

        <v-col cols="12" sm="3" md="3">
          <v-card class="pa-4 hoverable">
            <v-icon class="mb-2" color="blue" size="40">mdi-account-wrench</v-icon>
            <h2 class="text-h5 font-weight-bold">Cadastro de Técnicos</h2>
            <p>Cadastre os técnicos do seu setor e organize suas demandas.</p>
            <v-btn color="blue" block outlined @click="$router.push('/tecnicos')">
              Acessar
            </v-btn>
          </v-card>
        </v-col>

        <v-col cols="12" sm="3" md="3">
          <v-card class="pa-4 hoverable">
            <v-icon class="mb-2" color="orange" size="40">mdi-history</v-icon>
            <h2 class="text-h5 font-weight-bold">Histórico de Manutenções</h2>
            <p>Consulte todas as manutenções realizadas para cada equipamento.</p>
            <v-btn color="orange" block outlined @click="$router.push('/historico')">
              Acessar
            </v-btn>
          </v-card>
        </v-col>
      </v-row>
    </v-container>
  </v-app>
</template>
<script>
</script>

<style scoped>
.v-card {
  display: flex;
  flex-direction: column;
  height: 300px;
  justify-content: space-between;
}
</style>
