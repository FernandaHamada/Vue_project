<template>
  <div>
    <titulo
      :texto="
        professorId != undefined
          ? 'Professor(a): ' + professor.nome
          : 'Todos os Alunos'
      "
      :btnVoltar="true"
    />
    <div v-if="professorId != undefined">
      <input
        type="text"
        placeholder="Nome do Aluno(a)"
        v-model="nome"
        @keyup.enter="addAluno()"
      />
      <button @click="addAluno()" class="btn btnInput">Adicionar</button>
    </div>

    <table>
      <thead>
        <th>Matrícula</th>
        <th>Nome</th>
        <th>Opções</th>
      </thead>
      <tbody v-if="alunos.length">
        <tr v-for="(aluno, index) in alunos" :key="index">
          <!-- <td>{{ index + 1 }}</td> -->
          <td class="colPeq">{{ aluno.id }}</td>

          <router-link
            tag="td"
            :to="`/aluno-detalhe/${aluno.id}`"
            style="cursor: pointer"
          >
            {{ aluno.nome }} {{ aluno.sobrenome }}
          </router-link>
          <td>
            <button class="btn btn_Danger" @click="remover(aluno)">
              Remover
            </button>
          </td>
        </tr>
      </tbody>
      <tfoot v-else>
        Nenhum aluno encontrado
      </tfoot>
    </table>
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
      Titulo: "Aluno",
      professorId: this.$route.params.prof_id,
      professor: {},
      nome: "",
      alunos: [],
    };
  },
  created() {
    if (this.professorId) {
      this.carregarProfessores();
      this.$http
        .get("http://localhost:3000/alunos?professor.id=" + this.professorId)
        .then((res) => res.json())
        .then((alunos) => (this.alunos = alunos));
    } else {
      this.$http
        .get("http://localhost:3000/alunos")
        .then((res) => res.json())
        .then((alunos) => (this.alunos = alunos));
    }
  },
  props: {},
  methods: {
    addAluno() {
      let _aluno = {
        nome: this.nome,
        sobrenome: "",
        professor: {
          id: this.professor.id,
          nome: this.professor.nome,
        },
      };

      this.$http
        .post("http://localhost:3000/alunos", _aluno)
        .then((res) => res.json())
        .then((alunoRetornado) => {
          this.alunos.push(alunoRetornado);
          this.nome = "";
        });
    },

    remover(aluno) {
      this.$http.delete(`http://localhost:3000/alunos/${aluno.id}`).then(() => {
        let indice = this.alunos.indexOf(aluno);
        this.alunos.splice(indice, 1);
      });
    },

    carregarProfessores() {
      this.$http
        .get("http://localhost:3000/professores/" + this.professorId)
        .then((res) => res.json())
        .then((professor) => {
          this.professor = professor;
        });
    },
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.colPeq {
  text-align: center;
  width: 15%;
}

input {
  width: calc(100% - 195px);
  border: 0;
  padding: 20px;
  font-size: 1.3em;
  color: #687f7f;
  display: inline;
}

.btnInput {
  width: 150px;
  border: 0;
  padding: 20px;
  font-size: 1.3em;
  display: inline;
  background-color: rgb(116, 115, 115);
}

.btnInput:hover {
  padding: 20px;
  margin: 0;
  border: 0;
}
</style>
