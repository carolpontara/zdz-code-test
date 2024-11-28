<template>
  <v-app>
    <v-container>
      <v-row justify="center" class="mt-10">
        <v-col cols="12" md="8" class="text-center">
          <h1 class="text-h3 font-weight-bold">Historico de Registros</h1>
        </v-col>
      </v-row>

      <v-row class="mt-10" dense>
        <v-col cols="12" md="6">
          <h3 class="text-h5 font-weight-bold mb-2">Equipamentos Recentes</h3>
          <v-data-table dense :headers="equipamentosHeaders" :items="equipamentos" class="elevation-1">
            <template #no-data>
              <p>Nenhum equipamento cadastrado.</p>
            </template>
          </v-data-table>
        </v-col>
        <v-col cols="12" md="6">
          <h3 class="text-h5 font-weight-bold mb-2">Manutenções Recentes</h3>
          <v-data-table dense :headers="manutencoesHeaders" :items="manutencoes" class="elevation-1">
            <template #no-data>
              <p>Nenhuma manutenção registrada.</p>
            </template>
          </v-data-table>
        </v-col>
      </v-row>

      <v-row class="mt-10" dense>
        <v-col cols="12">
          <h3 class="text-h5 font-weight-bold mb-2">Técnicos</h3>
          <v-data-table dense :headers="tecnicosHeaders" :items="tecnicos" class="elevation-1">
            <template #no-data>
              <p>Nenhum técnico cadastrado.</p>
            </template>
          </v-data-table>
        </v-col>
      </v-row>
    </v-container>
  </v-app>
</template>

<script>
import axios from 'axios';

export default {
  data() {
    return {
      equipamentosHeaders: [
        { text: "Nome", value: "nome" },
        { text: "Tipo", value: "tipo" },
        { text: "Número de Série", value: "numeroSerie" },
        { text: "Status", value: "status" },
      ],
      equipamentos: [],
      manutencoesHeaders: [
        { text: "Data", value: "data" },
        { text: "Descrição", value: "descricao" },
        { text: "Equipamento", value: "equipamento" },
        { text: "Técnico", value: "tecnico" },
        { text: "Custo", value: "custo" },
        { text: "Status", value: "status" },
      ],
      manutencoes: [],
      tecnicosHeaders: [
        { text: "ID", value: "id" },
        { text: "Nome", value: "nome" },
        { text: "Especialidade", value: "especialidade" },
        { text: "Contato", value: "contato" },
      ],
      tecnicos: [],
    };
  },
  async created() {
    await Promise.all([this.getEquipamentos(), this.getManutencoes(), this.getTecnicos()]);
  },
  methods: {
    async getEquipamentos() {
      try {
        const response = await axios.get("https://localhost:7033/api/Equipamento");
        this.equipamentos = response.data.map(equipamento => ({
          nome: equipamento.nome,
          tipo: equipamento.tipo,
          numeroSerie: equipamento.numeroSerie,
          status: equipamento.status,
        }));
      } catch (error) {
        console.error("Erro ao buscar equipamentos:", error);
      }
    },
    async getManutencoes() {
      try {
        const response = await axios.get("https://localhost:7033/api/Manutencao");
        const manutencaoPromises = response.data.map(async (manutencao) => {
          let tecnicoNome = '';
          if (manutencao.tecnicoId) {
            try {
              const tecnicoResponse = await axios.get(`https://localhost:7033/api/Tecnico/${manutencao.tecnicoId}`);
              tecnicoNome = tecnicoResponse.data.nome;
            } catch (error) {
              console.error(`Erro ao buscar técnico com ID ${manutencao.tecnicoId}:`, error);
            }
          }

          let equipamentoNome = '';
          if (manutencao.equipamentoId) {
            try {
              const equipamentoResponse = await axios.get(`https://localhost:7033/api/Equipamento/${manutencao.equipamentoId}`);
              equipamentoNome = equipamentoResponse.data.nome;
            } catch (error) {
              console.error(`Erro ao buscar equipamento com ID ${manutencao.equipamentoId}:`, error);
            }
          }

          const dataFormatada = new Intl.DateTimeFormat('pt-BR').format(new Date(manutencao.data));

          const custoFormatado = new Intl.NumberFormat('pt-BR', {
            style: 'currency',
            currency: 'BRL',
          }).format(manutencao.custo);

          return {
            data: dataFormatada,
            descricao: manutencao.descricao,
            equipamento: equipamentoNome,
            tecnico: tecnicoNome,
            custo: custoFormatado,
            status: manutencao.status,
          };
        });

        this.manutencoes = await Promise.all(manutencaoPromises);
      } catch (error) {
        console.error("Erro ao buscar manutenções:", error);
      }
    },
    async getTecnicos() {
      try {
        const response = await axios.get("https://localhost:7033/api/Tecnico");
        this.tecnicos = response.data.map(tecnico => ({
          id: tecnico.id,
          nome: tecnico.nome,
          especialidade: tecnico.especialidade,
          contato: tecnico.contato,
        }));
      } catch (error) {
        console.error("Erro ao buscar técnicos:", error);
      }
    },
  },
};
</script>

<style scoped>
.v-card {
  display: flex;
  flex-direction: column;
  height: 300px;
  justify-content: space-between;
}
</style>
