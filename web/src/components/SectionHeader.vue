<template>
    <div class="appearance-none flex items-center justify-between inline-block text-cogs-yellow font-semibold bg-cogs-grey px-4 py-2 rounded">
        <span>{{title}}</span>
        <span            
            class="mx-2 bg-cogs-yellow inline-block rounded py-1 px-3 text-red-darker text-xs no-underline"
            @click="addClicked"
          ><i class="fas fa-plus"></i></span>
    </div>
</template>

<script>

export default {
  props: ["title"],
  components: { },
  methods: {
    addClicked: function() {
        this.$emit("addItem");
    }
  },
  data: function() {
    return {
      
    };
  }
};
</script>
