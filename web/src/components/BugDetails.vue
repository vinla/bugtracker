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
    </div>
</template>

<script>
export default {
    props: ["bug"],
    components: { },
    computed: {
        formattedDate() {
            return this.bug.createdOn.replace("T", " ").substring(0, 16);
        }
    }
}
</script>