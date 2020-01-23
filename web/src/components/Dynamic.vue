<template>
  <component
    :is="component"
    :data="modal.data"
    v-if="component"
    @reject="onReject"
    @accept="onAccept"
  />
</template>
<script>
export default {
  name: "dynamic",
  props: ["modal"],
  methods: {
    onReject: function() {
      this.$cancelModal();
    },
    onAccept: function(result) {
      this.$cancelModal();
      if (this.modal.resolve) {
        this.modal.resolve(result);
      }
    }
  },
  computed: {
    component() {
      if (!this.modal || !this.modal.component) {
        return null;
      }
      const tp = `@/${this.modal.component}`;
      return () => import(tp);
    }
  }
};

</script>
