<template>
    <div class="border-b" @click="this.select">
        <span class="inline-block bg-gray-200 rounded-full px-3 py-1 text-sm font-semibold text-gray-700 mr-2">{{bug.id}}</span>
        <span class="inline-block px-3 py-1 mr-2">{{bug.title}}</span>
    </div>
</template>

<script>

export default {
  props: ["bug"],
  components: { },
  methods: {
    select: function() {
        this.$emit("selected", this.bug);
    }
  },
  data: function() {
    return {
      
    };
  }
};
</script>
