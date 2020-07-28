import Vue from "vue";
import Router from "vue-router";

import Aluno from "./components/Aluno/Aluno";
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
      path: "/alunos",
      name: "Alunos",
      component: Aluno,
    },
    {
      path: "/sobre",
      name: "Sobre",
      component: Sobre,
    },
  ],
});
