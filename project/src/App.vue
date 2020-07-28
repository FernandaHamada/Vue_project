<template>
  <div id="app">
    <Aluno />
  </div>
</template>

<script>
import Aluno from "./components/Aluno/Aluno.vue";

export default {
  name: "App",
  components: {
    Aluno,
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

#app {
}

.btn_Danger {
  background-color: #fa4430;
}

.btn {
  border: 1px solid black;
  cursor: pointer;
  padding: 10px 20px;
  color: white;
  font-weight: bold;
  border-radius: 5px;
  border-bottom: 3px solid black;
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
}
</style>
