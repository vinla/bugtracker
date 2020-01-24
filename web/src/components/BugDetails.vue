<template>
    <div class="px-6 py-2">
        <div class="py-2">
            <span class="font-semibold">[{{bug.id}}]</span> 
            <span class="pl-5 font-bold">{{bug.title}}</span>
        </div>
        <div class="text-sm">
        {{this.formattedDate}}
        </div>
        <div class="py-2 italic">{{bug.description}}</div>
        <div v-if="assignedTo">Assigned to: {{assignedTo.name}}</div>
        <div v-if="!assignedTo">Unassigned</div>
        <div class="border-t pt-4 mt-2 flex justify-center">
          <button class="bg-cogs-grey px-4 py-2 mx-2 rounded text-cogs-yellow" @click="$emit('assign')">Assign</button>
          <button class="bg-cogs-grey px-4 py-2 rounded text-cogs-yellow" @click="$emit('close')">Close</button>
        </div>
    </div>
</template>

<script>
export default {
    props: ["bug"],
    components: { },
    computed: {
        formattedDate() {
            return this.bug.createdOn.replace("T", " ").substring(0, 16);
        },
        assignedTo() {
            return this.$store.state.users.find(user => user.id == this.bug.assignedTo); 
        }
    }
}
</script>