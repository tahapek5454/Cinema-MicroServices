import {Component, Prop, Vue} from 'vue-property-decorator';


@Component
export default class CategoryCard extends Vue {
    @Prop() private name: string;
    @Prop() private icon: string;

}