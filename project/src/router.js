import Vue from "vue";
import Router from "vue-router";

import Aluno from "./components/Aluno/Aluno";
import AlunoEdit from "./components/Aluno/AlunoEdit";
import Professor from "./components/Professor/Professor";
import Sobre from "./components/Sobre/Sobre";

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: "/professores",
      name: "Professores",
      component: Professor,
    },
    {
      path: "/alunos/:prof_id",
      name: "Alunos",
      component: Aluno,
    },
    {
      path: "/todos-alunos",
      name: "Alunos",
      component: Aluno,
    },
    {
      path: "/aluno-detalhe/:id",
      name: "Alunos-Detalhe",
      component: AlunoEdit,
    },
    {
      path: "/sobre",
      name: "Sobre",
      component: Sobre,
    },
  ],
});
