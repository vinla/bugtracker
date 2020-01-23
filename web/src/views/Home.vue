<template>
  <div>
    <div class="flex mx-auto p-6">
      <div class="w-1/4 p-2">
        <SectionHeader :title="'Open Bugs'" @addItem="createBug"/>
        <ul class="mx-auto list-reset bg-gray">
          <li v-for="bug in bugs" v-bind:key="bug.id">
            <BugListItem :bug="bug" @selected="selectBug" />
          </li>
        </ul>           
      </div>
      <div class="w-1/2 bg-gray p-2">
        <div class="appearance-none flex items-center inline-block text-cogs-yellow font-semibold bg-cogs-grey px-4 py-2 rounded">Bug Details</div>
        <div v-if="this.selectedBug" class="px-6 py-2">
          <span class="font-bold">[{{this.selectedBug.id}}]</span> 
          <span class="pl-5">{{this.selectedBug.title}}</span>
          <div>
            {{this.selectedBug.createdOn}}
          </div>
          <div>{{this.selectedBug.description}}</div>
        </div>
      </div>
      <div class="w-1/4 p-2"> 
        <SectionHeader :title="'Users'" />
        <ul class="mx-auto list-reset bg-gray">
          <li v-for="user in users" v-bind:key="user.id">
            <div class="border-b p-2">{{user.name}}</div>
          </li>
        </ul>
      </div>
    </div>
  </div>
</template>

<script>
import bugsService from "../services/bugsService";
import usersService from "../services/usersService";
import BugListItem from "../components/BugListItem";
import Dynamic from "../components/Dynamic";
import SectionHeader from "../components/SectionHeader";

export default {
  name: "home",
  components: {
    BugListItem,
    Dynamic,
    SectionHeader
  },
  created: function() {
    this.refreshBugs();
    this.refreshUsers();
  },
  methods: {
    selectBug: function(bug) {
      this.selectedBug = bug;
    },
    refreshBugs: function() {
      bugsService.listBugs().then(data => {
        this.bugs = data;
      });
    },
    refreshUsers: function() {
      usersService.listUsers().then(data => {
        this.users = data;
      });
    },
    createBug: function() {
      this.$showModal({
        component: "modals/CreateBug",
        data: {}
      }).then(r => {

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
      bugs: [],
      users: [],
      selectedBug: null
    };
  }
};
</script>
