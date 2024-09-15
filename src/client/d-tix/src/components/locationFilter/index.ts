import { Component, Prop, Vue } from 'vue-property-decorator';

@Component
export default class LocationFilter extends Vue {

    
}

export interface Result {
    combo1: string;
    combo2: string;
    text: string;
    adress: string;
}
  
export interface ComboBoxProps {
    options1: string[];
    options2: string[];
    results: Result[];
}