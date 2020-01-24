<template>
    <div
    class="rounded border border-black bg-white block"
    style="width: 450px; height: 150px; margin-top: 300px;"
  >
        <div class="px-2 py-2 text-cogs-yellow font-semibold bg-cogs-grey block">{{data.title}}</div>
        <div class="p-4">
            <div class="my-2">{{data.prompt}}</div>
            <div class="border-t pt-4 flex justify-end">
                <button class="bg-green-dark px-4 py-2 mx-2 rounded text-white" type="button" @click="$emit('accept')">{{acceptText}}</button>
                <button class="bg-red px-4 py-2 rounded text-white" @click="$emit('reject')">Cancel</button>
            </div>
      </div>
    </div>
</template>

<script>
export default {
    props: ['data'],
    computed: {
        placeholder: function() {
            if(this.data.hasOwnProperty('placeholder')) {
                return this.data.placeholder;
            }

            return '';
        },
        acceptText: function() {
            if(this.data.hasOwnProperty('acceptText')) {
                return this.data.acceptText;
            }

            return 'Ok';
        }
    }
}
</script>
