import { Component, Vue } from 'vue-property-decorator';

@Component
export default class Spinner extends Vue {
    render = false;
    
    created() {
        this.$root.$on("spinner", (val: boolean) => {
            this.render = val;
        });
    }
    destroyed() {
        this.$root.$off("spinner");
    }
}