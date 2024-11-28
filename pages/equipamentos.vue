<template>
  <div class="form-container">
    <h2 class="title">Cadastro de Equipamento</h2>
    <form @submit.prevent="handleSubmit" class="form">
      <div class="input-field">
        <label for="Nome" class="form-label">Nome do Equipamento</label>
        <input v-model="equipamento.Nome" type="text" id="Nome" required class="input" />
      </div>

      <div class="input-field">
        <label for="tipo" class="form-label">Tipo do Equipamento</label>
        <input v-model="equipamento.tipo" type="text" id="tipo" required class="input" />
      </div>

      <div class="input-field">
        <label for="numeroSerie" class="form-label">Número de Série</label>
        <input v-model="equipamento.numeroSerie" type="text" id="numeroSerie" required class="input" />
      </div>

      <div class="input-field">
        <label for="status" class="form-label">Status</label>
        <select v-model="equipamento.status" id="status" required class="input">
          <option v-for="status in statusOptions" :key="status" :value="status">{{ status }}</option>
        </select>
      </div>

      <button type="submit" class="submit-btn">Salvar Equipamento</button>
    </form>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  data() {
    return {
      equipamento: {
        Nome: '',
        tipo: '',
        numeroSerie: '',
        status: '',
      },
      statusOptions: ['Inspecionado', 'Disponível'],
    };
  },
  methods: {
    async handleSubmit() {
      try {
        const response = await axios.post('https://localhost:7033/api/Equipamento', this.equipamento);

        if (response.status === 201) { // Mudança de 200 para 201
          alert('Equipamento salvo com sucesso!');
          this.equipamento = { nome: '', tipo: '', numeroSerie: '', status: '' };
        }
      } catch (error) {
        console.error('Erro ao salvar equipamento:', error);
        if (error.response && error.response.data) {
          alert(error.response.data);
        } else {
          alert('Erro ao salvar o equipamento. Verifique os detalhes no console.');
        }
      }
    },
  }
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
