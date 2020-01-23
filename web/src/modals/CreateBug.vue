<template>
  <div
    class="rounded border border-black bg-white block"
    style="width: 450px; height: 250px; margin-top: 300px;"
  >
    <div class="px-2 py-2 bg-cogs-primary text-cogs-secondary block">Create a bug</div>
    <div class="p-6">
      <div>Title</div>
      <div>Description</div>
      <button class="bg-green-dark px-4 py-2 rounded text-white" @click="$emit('accept', {selectedDeck})">Create</button>
      <button class="bg-red px-4 py-2 rounded text-white" @click="$emit('reject')">Cancel</button>
    </div>
  </div>
</template>

<script>
export default {
  props: ["data"],
  mounted: function() {},
  data: function() {
    return {
      selectedDeck: null
    }
  }
};
</script>

