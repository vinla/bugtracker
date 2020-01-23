<template>
  <div>
    <div class="flex mx-auto p-6">
      <ul class="w-1/3 mx-auto list-reset">
        <li v-for="bug in bugs" v-bind:key="bug.id">
          <div>
            <span class="inline-block bg-gray-200 rounded-full px-3 py-1 text-sm font-semibold text-gray-700 mr-2">{{bug.id}}</span>
            <span class="inline-block px-3 py-1 mr-2">{{bug.title}}</span>
          </div>
        </li>
      </ul>
      <div class="w-2/3 bg-gray">
        Select a bug to see the details
      </div>
    </div>
  </div>
</template>

<script>
import bugsService from "../services/bugsService";

export default {
  name: "home",
  components: {

  },
  created: function() {
    this.refreshBugs();
  },
  methods: {
    selectBug: function(game) {

    },
    refreshBugs: function() {
      bugsService.listBugs().then(data => {
        this.bugs = data;
      });
    }
  },
  computed: {
    filteredBugs: function() {
      if (this.bugs) {
        return this.bugs.filter(b => this.showClosed || !b.isClosed);
      }
      return [];
    }
  },
  data: function() {
    return {
      showClosed: false,
      bugs: []
    };
  }
};
</script>
