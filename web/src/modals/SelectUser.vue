<template>
    <div
    class="rounded border border-black bg-white block"
    style="width: 450px; height: 200px; margin-top: 300px;"
  >
        <div class="px-2 py-2 text-cogs-yellow font-semibold bg-cogs-grey block">Select a user</div>
        <div class="p-4">
            <div class="my-2">Users</div>
            <select v-model="value">
                <option value="">Unassign</option>
                <option v-for="user in users" v-bind:key="user.id" :value="user.id">{{user.name}}</option>
            </select>
            <div class="border-t pt-4 flex justify-end">
                <button class="bg-green-dark px-4 py-2 mx-2 rounded text-white" type="button" @click="$emit('accept', {value})">Assign</button>
                <button class="bg-red px-4 py-2 rounded text-white" @click="$emit('reject')">Cancel</button>
            </div>
      </div>
    </div>
</template>

<script>
export default {
    computed: {    
        users : function() {
            return this.$store.state.users;
        }
    },
    data: function() {
        return {
            value: ''
        }
    }    
}
</script>
