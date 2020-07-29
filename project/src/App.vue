<template>
  <div id="app">
    <Nav></Nav>
    <div class="margemPrincipal">
      <router-view :key="$route.fullPath"></router-view>
    </div>
  </div>
</template>

<script>
import Aluno from "./components/Aluno/Aluno";
import Professor from "./components/Professor/Professor";
import Sobre from "./components/Sobre/Sobre";
import Nav from "./components/_nav/Nav";

export default {
  name: "App",
  components: {
    /* eslint-disable vue/no-unused-components */
    Aluno,
    Professor,
    Sobre,
    Nav,
  },
};
</script>

<style>
@import url("https://fonts.googleapis.com/css2?family=Montserrat:wght@400;700&display=swap");

body {
  background-color: #eee;
  font-family: "Montserrat", sans-serif;
  display: grid;
  justify-items: center;
}

body,
html {
  margin: 0;
  height: 100%;
}

.margemPrincipal {
  width: 50%;
  margin: auto;
}

#app {
  width: 100%;
}

.btn_Danger {
  background-color: #fa4430;
  font-size: 0.8em !important;
}

.btn {
  border: 1px solid black;
  cursor: pointer;
  padding: 10px 20px;
  color: white;
  font-weight: bold;
  border-radius: 5px;
  border-bottom: 3px solid black;
  font-size: 1.2em;
}

.btn:hover {
  text-shadow: 1px 1px 1px black;
  margin-top: 3px;
  border-bottom: 1px solid black;
}

table {
  margin: 0;
  padding: 0;
  list-style-type: none;
  width: 100%;
}

table tr td {
  padding: 20px;
  font-size: 1.3em;
  background-color: #e0edf4;
  margin-bottom: 2px;
  color: #3e5252;
}

table thead th {
  background-color: rgb(184, 208, 216) !important;
  font-size: 1.2em;
  padding: 10px 0px;
  text-align: center !important;
}

.colPeq {
  width: 5%;
  text-align: right;
  background-color: rgb(125, 217, 245);
  font-weight: bold;
}
</style>
