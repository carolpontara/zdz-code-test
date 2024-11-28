<template>
  <div class="form-container">
    <h2 class="title">Cadastro de Manutenções</h2>
    <form @submit.prevent="submitForm" class="form">
      <div class="input-field">
        <label for="data" class="form-label">Data da Manutenção</label>
        <input v-model="formData.data" type="date" id="data" required class="input" />
      </div>

      <div class="input-field">
        <label for="descricao" class="form-label">Descrição</label>
        <textarea v-model="formData.descricao" id="descricao" rows="4" required class="input"></textarea>
      </div>

      <div class="input-field">
        <label for="custo" class="form-label">Custo</label>
        <input v-model="formData.custo" type="number" step="0.01" id="custo" required class="input" />
      </div>

      <div class="input-field">
        <label for="status" class="form-label">Status</label>
        <select v-model="formData.status" id="status" required class="input">
          <option value="pendente">Pendente</option>
          <option value="concluída">Concluída</option>
          <option value="em andamento">Em andamento</option>
        </select>
      </div>

      <div class="input-field">
        <label for="equipamentoId" class="form-label">Equipamento</label>
        <select v-model="formData.equipamentoId" id="equipamentoId" required class="input">
          <option v-for="equipamento in equipamentos" :key="equipamento.id" :value="equipamento.id">
            {{ equipamento.nome }}
          </option>
        </select>
      </div>

      <div class="input-field">
        <label for="tecnicoId" class="form-label">Técnico</label>
        <select v-model="formData.tecnicoId" id="tecnicoId" required class="input">
          <option v-for="tecnico in tecnicos" :key="tecnico.id" :value="tecnico.id">
            {{ tecnico.nome }}
          </option>
        </select>
      </div>

      <button type="submit" class="submit-btn">Cadastrar Manutenção</button>
    </form>
  </div>
</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      formData: {
        data: "",
        descricao: "",
        custo: "",
        status: "pendente",
        equipamentoId: null,
        tecnicoId: null,
      },
      equipamentos: [],
      tecnicos: [],
    };
  },
  methods: {
    async submitForm() {
      try {
        const response = await axios.post(
          "https://localhost:7033/api/Manutencao",
          this.formData,
          {
            headers: {
              'Content-Type': 'application/json',
            }
          }
        );

        if (response.status === 201) {
          alert("Manutenção cadastrada com sucesso!");
          this.clearForm();
        } else {
          alert("Erro ao cadastrar manutenção");
        }
      } catch (error) {
        console.error("Erro ao enviar os dados:", error);
        alert("Erro de conexão ou dados inválidos");
      }
    },
    async loadEquipamentos() {
      try {
        const response = await axios.get("https://localhost:7033/api/Equipamento");
        this.equipamentos = response.data;
      } catch (error) {
        console.error("Erro ao carregar equipamentos:", error);
        alert("Erro ao carregar equipamentos");
      }
    },
    async loadTecnicos() {
      try {
        const response = await axios.get("https://localhost:7033/api/Tecnico");
        this.tecnicos = response.data;
      } catch (error) {
        console.error("Erro ao carregar técnicos:", error);
        alert("Erro ao carregar técnicos");
      }
    },
    clearForm() {
      this.formData = {
        data: "",
        descricao: "",
        custo: "",
        status: "pendente",
        equipamentoId: null,
        tecnicoId: null,
      };
    },
  },
  mounted() {
    this.loadEquipamentos();
    this.loadTecnicos();
  },
};
</script>

<style scoped>
.form-container {
  max-width: 100%;
  margin: 50px auto;
  padding: 40px;
  background-color: #000;
  border-radius: 12px;
  border: 2px solid #3498db;
  box-shadow: 0 8px 20px rgba(0, 0, 0, 0.2);
  width: 100%;
  box-sizing: border-box;
}

.title {
  text-align: center;
  font-size: 30px;
  margin-bottom: 40px;
  color: #fff;
}

.form {
  display: flex;
  flex-direction: column;
  gap: 24px;
}

.input-field {
  background-color: #fff;
  border: 1px solid #ddd;
  border-radius: 8px;
  padding: 14px;
  font-size: 16px;
  color: #333;
  transition: all 0.3s ease;
}

.input-field:focus {
  border-color: #3498db;
  outline: none;
  box-shadow: 0 0 8px rgba(52, 152, 219, 0.5);
}

.input {
  width: 100%;
  padding: 12px 16px;
  font-size: 16px;
  border-radius: 8px;
  border: 1px solid #ddd;
  transition: border-color 0.3s ease;
}

.input:focus {
  outline: none;
  border-color: #3498db;
  box-shadow: 0 0 8px rgba(52, 152, 219, 0.5);
}

.submit-btn {
  background-color: #3498db;
  color: white;
  font-weight: bold;
  padding: 12px 25px;
  border-radius: 30px;
  box-shadow: 0 6px 12px rgba(52, 152, 219, 0.2);
  transition: all 0.3s ease;
  width: 100%;
}

.submit-btn:hover {
  background-color: #2980b9;
  box-shadow: 0 8px 18px rgba(52, 152, 219, 0.3);
}

@media (max-width: 768px) {
  .form-container {
    margin: 20px;
    padding: 25px;
  }
  .title {
    font-size: 24px;
  }
  .input-field {
    margin-bottom: 15px;
  }
  .submit-btn {
    padding: 10px 20px;
  }
}

@media (max-width: 480px) {
  .title {
    font-size: 20px;
  }
  .form-container {
    padding: 20px;
    margin: 15px;
  }
  .input {
    font-size: 14px;
    padding: 10px 12px;
  }
  .submit-btn {
    padding: 10px 18px;
  }
}

</style>
