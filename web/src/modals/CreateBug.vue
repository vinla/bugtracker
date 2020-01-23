<template>
  <div
    class="rounded border border-black bg-white block"
    style="width: 450px; height: 300px; margin-top: 300px;"
  >
    <div class="px-2 py-2 text-cogs-yellow font-semibold bg-cogs-grey block">Create a bug</div>
    <div class="p-4">
      <div class="my-2">Title</div>
      <input v-model="bugTitle"
                :placeholder="'Enter a title for the bug'"
                class="bg-white appearance-none
                border-2 border-grey-darker rounded
                w-full py-2 px-4 text-grey-darker leading-tight
                focus:outline-none" type="text">      
      <div class="my-2">Description</div>
      <textarea v-model="bugDescription"
                :placeholder="'Enter a description for the bug'"
                class="bg-white appearance-none
                border-2 border-grey-darker rounded
                w-full py-2 px-4 text-grey-darker leading-tight
                focus:outline-none" type="text" style="height: 80px;"/>      
      <div class="border-t pt-4 flex justify-end">
        <button class="bg-green-dark px-4 py-2 mx-2 rounded text-white" @click="$emit('accept', {bugTitle, bugDescription})">Create</button>
        <button class="bg-red px-4 py-2 rounded text-white" @click="$emit('reject')">Cancel</button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: ["data"],
  mounted: function() {},
  data: function() {
    return {
      bugTitle: "",
      bugDescription: ""
    }
  }
};
</script>

