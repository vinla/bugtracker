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
        <BugDetails v-if="selectedBug" :bug="selectedBug" />
      </div>
      <div class="w-1/4 p-2"> 
        <SectionHeader :title="'Users'" @addItem="createUser"/>
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
import CreatBug from "../modals/CreateBug";
import SimplePrompt from "../modals/SimplePrompt";
import BugDetails from "../components/BugDetails";

export default {
  name: "home",
  components: {
    BugDetails,
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
        component: CreatBug,
        data: {}
      }).then(r => {
        bugsService.createBug(r.bugTitle, r.bugDescription).then(d => this.refreshBugs());
      });
    },
    createUser: function() {
      this.$showModal({
        component: SimplePrompt,
        data: {
          prompt: "User name",
          title: "Create user",
          acceptText: "Create"
        }
      }).then(r => {
        usersService.createUser(r.value).then(d => this.refreshUsers());
      })
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
