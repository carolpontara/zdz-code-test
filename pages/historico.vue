<template>
  <v-container>
    <v-row class="mt-10" dense>
      <v-col cols="12" md="12">
        <h3 class="text-h5 font-weight-bold mb-2">Manutenções Recentes</h3>
        <v-data-table dense :headers="manutencoesHeaders" :items="manutencoes" class="elevation-1" item-value="id"
          :items-per-page="5" style="max-width: 100%;">
          <template #no-data>
            <p>Nenhuma manutenção registrada.</p>
          </template>
        </v-data-table>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  data() {
    return {
      manutencoesHeaders: [
        { text: 'Data', align: 'start', key: 'data' },
        { text: 'Descrição', align: 'start', key: 'descricao' },
        { text: 'Custo', align: 'start', key: 'custo' },
        { text: 'Status', align: 'start', key: 'status' },
        { text: 'Equipamento', align: 'start', key: 'equipamento' },
        { text: 'Técnico', align: 'start', key: 'tecnico' }
      ],
      manutencoes: [
        {
          "id": 1,
          "data": "2024-11-01",
          "descricao": "Substituição de peça",
          "custo": 500.00,
          "status": "Concluído",
          "equipamento": "Esteira",
          "tecnico": "Carlos Silva"
        },
        {
          "id": 2,
          "data": "2024-11-15",
          "descricao": "Reparos gerais",
          "custo": 300.00,
          "status": "Pendente",
          "equipamento": "Gerador",
          "tecnico": "Ana Paula"
        }
      ]
    };
  },
  methods: {
    async loadManutencoes() {
      try {
        const response = await fetch('API_URL/manutencoes');
        this.manutencoes = await response.json();
      } catch (error) {
        console.error(error);
        alert('Erro ao carregar histórico de manutenções');
      }
    }
  },
  mounted() {
    this.loadManutencoes();
  }
};
</script>

<style scoped>
.text-h5 {
  font-size: 24px;

  .v-data-table {
    margin-top: 20px;
    width: 100%;
  }

  .v-data-table th,
  .v-data-table td {
    font-size: 16px;
  }

  @media (max-width: 768px) {

    .v-data-table th,
    .v-data-table td {
      font-size: 14px;
    }

    .text-h5 {
      font-size: 20px;
    }
  }

  @media (max-width: 480px) {

    .v-data-table th,
    .v-data-table td {
      font-size: 12px;
    }

    .text-h5 {
      font-size: 18px;
    }
  }
}
</style>
