<template>
  <div>
    <titulo texto="Professores" />
    <table>
      <thead>
        <th>Código</th>
        <th>Nome</th>
        <th>Alunos</th>
      </thead>
      <tbody v-if="Professores.length">
        <tr v-for="(professor, index) in Professores" :key="index">
          <!-- <td>{{ index + 1 }}</td> -->
          <td>{{ professor.id }}</td>
          <router-link to="/alunos" tag="td" style="cursor: pointer">
            {{ professor.nome }} {{ professor.sobrenome }}
          </router-link>
          <td>3</td>
        </tr>
      </tbody>
      <tfoot v-else>
        Nenhum professor encontrado
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
      Professores: [
        { id: 1, nome: "Fernanda" },
        { id: 2, nome: "Paulo" },
        { id: 3, nome: "Luis" },
      ],
    };
  },
};
</script>

<style scoped></style>
