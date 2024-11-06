import { Component, Prop, Vue } from 'vue-property-decorator';
import Base from "@/utils/Base";
import Modal from "@/components/modal/index.vue";
import MovieSelection from "@/components/movieSelection/index.vue";
import TheaterHall from "@/components/theaterhall/index.vue";

@Component({
    components: {
        Modal,
        MovieSelection,
        TheaterHall
    }
})
export default class QuickReservation extends Base {
    @Prop({default:false}) isOpenModal!: boolean;

    sectionStep:number = 0;
    created(): void {
        console.log(this.isOpenModal);
    }

    destroyed(): void {

    }

    mounted(): void {
    }

    next(step:number){
        if(this.sectionStep+step == 2){
            this.$toast.success("Rezervasyonun tamamlandı 😊");
            return;
        }

        if(this.sectionStep + step > 1 || this.sectionStep + step < 0){
            this.$toast.warning("Adım sayısının dışına çıkamazsınız 😊");
            return;
        }
        this.sectionStep = this.sectionStep + step;
    }
}