<template>
  <div id="app">
    <div class="fixed pin z-50 overflow-auto bg-overlay flex justify-center" v-show="$modal">
      <dynamic :modal="$modal"/>
    </div>
    <div class="bg-cogs-black">
      <nav class="w-full py-3 px-6 mx-auto" id="banner">
        <span>
          <router-link
            to="/"
            class="text-cogs-yellow font-semibold text-xl tracking-tight no-underline"
          >Bugtracker</router-link>
        </span>
      </nav>
    </div>
    <router-view/>
  </div>
</template>

<script>
import Dynamic from "./components/Dynamic";

export default {
  name: "App",
  components: { Dynamic },
  mounted: function() {
    //this.$store.dispatch('retrieveProfile');
  },
  computed: {

  },
  data: function() {
    return {
    };
  }
};
</script>

<style>
@import url("http://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,700italic,300,400,700");
#app {
  font-family: "Open Sans", sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: left;
  color: #2c3e50;
}

.bg-overlay {
  background-color: rgba(0, 0, 0, 0.4);
}
</style>
