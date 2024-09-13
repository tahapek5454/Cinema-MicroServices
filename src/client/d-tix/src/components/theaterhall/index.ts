import { Component, Vue } from 'vue-property-decorator';
import TheaterSeat from '../theaterSeat/index.vue';


@Component({
    components:{
        TheaterSeat
    }
})
export default class TheaterHall extends Vue {
    seats: Seat[] = [
        {key: 'A', value:'1'},
        {key: 'A', value:'2'},
        {key: 'A', value:'3'},
        {key: 'A', value:'4'},
        {key: 'A', value:'5'},
        {key: 'A', value:'6'},
        {key: 'A', value:'7'},
        {key: 'A', value:'8'},
        {key: 'A', value:'9'},
        {key: 'A', value:'10'},

        {key: 'B', value:'1'},
        {key: 'B', value:'2'},
        {key: 'B', value:'3'},
        {key: 'B', value:'4'},
        {key: 'B', value:'5'},
        {key: 'B', value:'6'},
        {key: 'B', value:'7'},
        {key: 'B', value:'8'},
        {key: 'B', value:'9'},
        {key: 'B', value:'10'},

        {key: 'C', value:'1'},
        {key: 'C', value:'2'},
        {key: 'C', value:'3'},
        {key: 'C', value:'4'},
        {key: 'C', value:'5'},
        {key: 'C', value:'6'},
        {key: 'C', value:'7'},
        {key: 'C', value:'8'},
        {key: 'C', value:'9'},
        {key: 'C', value:'10'},
        
        {key: 'D', value:'1'},
        {key: 'D', value:'2'},
        {key: 'D', value:'3'},
        {key: 'D', value:'4'},
        {key: 'D', value:'5'},
        {key: 'D', value:'6'},
        {key: 'D', value:'7'},
        {key: 'D', value:'8'},
        {key: 'D', value:'9'},
        {key: 'D', value:'10'},

        {key: 'E', value:'1'},
        {key: 'E', value:'2'},
        {key: 'E', value:'3'},
        {key: 'E', value:'4'},
        {key: 'E', value:'5'},
        {key: 'E', value:'6'},
        {key: 'E', value:'7'},
        {key: 'E', value:'8'},
        {key: 'E', value:'9'},
        {key: 'E', value:'10'},
    ]

    get filteredSeatsForA(): Seat[] {
        return this.seats.filter(seat => seat.key === 'A');
    }
    get filteredSeatsForB(): Seat[] {
        return this.seats.filter(seat => seat.key === 'B');
    }
    get filteredSeatsForC(): Seat[] {
        return this.seats.filter(seat => seat.key === 'C');
    }
    get filteredSeatsForD(): Seat[] {
        return this.seats.filter(seat => seat.key === 'D');
    }
    get filteredSeatsForE(): Seat[] {
        return this.seats.filter(seat => seat.key === 'E');
    }
}

interface Seat{
    key:string;
    value:string;
}