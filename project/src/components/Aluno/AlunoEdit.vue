<template>
  <div v-if="!loading">
    <titulo :texto="`Aluno(a): ${aluno.nome}`" :btnVoltar="!visualizar">
      <button v-show="visualizar" class="btn btnEditar" @click="editar()">Editar</button>
    </titulo>
    <table>
      <tbody>
        <tr>
          <td class="colPeq">Matrícula:</td>
          <td>
            <label>{{ aluno.id }}</label>
          </td>
        </tr>
        <tr>
          <td class="colPeq">Nome:</td>
          <td>
            <label v-if="visualizar">{{ aluno.nome }}</label>
            <input v-else v-model="aluno.nome" type="text" />
          </td>
        </tr>
        <tr>
          <td class="colPeq">Sobrenome:</td>
          <td>
            <label v-if="visualizar">{{ aluno.sobrenome }}</label>
            <input v-else v-model="aluno.sobrenome" type="text" />
          </td>
        </tr>
        <tr>
          <td class="colPeq">Data de Nascimento:</td>
          <td>
            <label v-if="visualizar">{{ aluno.dataNasc }}</label>
            <input v-else v-model="aluno.dataNasc" type="text" />
          </td>
        </tr>
        <tr>
          <td class="colPeq">Professor(a)</td>
          <td>
            <label v-if="visualizar">{{ aluno.professor.nome }}</label>
            <select v-else v-model="aluno.professor.id">
              <option
                v-for="(professor, index) in professores"
                :key="index"
                v-bind:value="professor.id"
              >{{ professor.nome }}</option>
            </select>
          </td>
        </tr>
      </tbody>
    </table>

    <div style="margin-top: 10px;">
      <div v-if="!visualizar">
        <button class="btn btnSalvar" @click="salvar(aluno)">Salvar</button>
        <button class="btn btnCancelar" @click="cancelar()">Cancelar</button>
      </div>
    </div>
  </div>
</template>

<script>
import Titulo from "../_share/Titulo";

export default {
  components: {
    Titulo,
  },
  data() {
    return {
      professores: [],
      aluno: {},
      idAluno: this.$route.params.id,
      visualizar: true,
      loading: true,
    };
  },
  created() {
    this.carregarProfessor();
  },

  methods: {
    carregarProfessor() {
      this.$http
        .get("http://localhost:5000/api/professor")
        .then((res) => res.json())
        .then((professor) => {
          this.professores = professor;
          this.carregarAluno();
        });
    },

    carregarAluno() {
      this.$http
        .get(`http://localhost:5000/api/alunos/${this.idAluno}`)
        .then((res) => res.json())
        .then((aluno) => {
          this.aluno = aluno;
          this.loading = false;
        });
    },

    editar() {
      this.visualizar = !this.visualizar;
    },

    salvar(_aluno) {
      let _alunoEdit = {
        id: _aluno.id,
        nome: _aluno.nome,
        sobrenome: _aluno.sobrenome,
        dataNasc: _aluno.dataNasc,
        professorId: _aluno.professor.id,
      };

      this.$http
        .put(`http://localhost:5000/api/alunos/${_alunoEdit.id}`, _alunoEdit)
        .then((res) => res.json())
        .then((aluno) => (this.aluno = aluno));

      this.visualizar = !this.visualizar;
    },

    cancelar() {
      this.visualizar = !this.visualizar;
    },
  },
};
</script>

<style scoped>
.btnEditar {
  float: right;
  background-color: rgb(76, 186, 249);
}

.btnSalvar {
  float: right;
  background-color: rgb(79, 196, 68);
}

.btnCancelar {
  background-color: rgb(249, 186, 92);
}

.colPeq {
  width: 20%;
}

input,
select {
  margin: 0px;
  padding: 5px 10px;
  font-size: 0.9em;
  border: 1px solid silver;
  border-radius: 5px;
  font-family: Montserrat;
  width: 95%;
  background-color: rgb(245, 245, 245);
}

select {
  height: 38px;
  width: 100%;
}
</style>
