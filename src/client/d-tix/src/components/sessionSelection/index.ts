import { Component, Vue, Watch,Prop } from 'vue-property-decorator';
import Base from "@/utils/Base";
import {Repositories, RepositoryFactory} from "@/services/RepositoryFactory";
import MovieDto from "@/models/movies/MovieDto";
import MovieSelectionCard from "@/components/movieSelection/movieSelectionCard/index.vue";
import { SessionRepository } from '@/Repositories/SessionRepository';
import SessionSelectionCard from './sessionSelectionCard/index.vue';
import SessionDto from '@/models/session/SessionDto';

const _sessionRepository = RepositoryFactory(Repositories.SessionRepository) as SessionRepository;


interface SessionSelectionCardModel{
    session:SessionDto;
    isSelected:boolean;
}

@Component({
    components:{
        SessionSelectionCard
    }
})
export default class SessionSelection extends Base {

    @Prop({}) selectMovieForReservation!: number;
    @Prop({}) selectBranchForReservation!: number;
    @Prop({default:null}) selectSessionForReservation!: number;
    sessionSelectionCardDatas: SessionSelectionCardModel [] = [];
    itemCount: number = 0;

    destroyed(): void {
    }

    mounted(): void {
    }

    days:string[]=[];
    visibleItems:string[]=[];
    daysVisible: number = 4;
    currentIndex: number = 0;
    selectedDate: string = '';
    selectedSession:string='';
    filteredResults: SessionDto[] = [];
  
    created() {
      this.currentIndex = 0;
      this.days = this.generateDays(0);
    }

    getAllSession(){
        const movieId = this.selectMovieForReservation;  // Props'dan gelen movieId
        const branchId = this.selectBranchForReservation; // Props'dan gelen branchId
        if(branchId != undefined && movieId != undefined){
            this.showLoading();
          _sessionRepository.GetAllSessionsByBranchAndMovieId(branchId,movieId)
          .then((r)=>{
            this.itemCount = r.length;
            this.sessionSelectionCardDatas = [];
            r.forEach(item => {
                if(!this.selectSessionForReservation){
                    this.sessionSelectionCardDatas.push({
                        session :item,
                        isSelected : false,
                    });
                }else{
                    if(item.id == this.selectSessionForReservation){
                        this.sessionSelectionCardDatas.push({
                            session :item,
                            isSelected : true,
                        });
                    }else{
                        this.sessionSelectionCardDatas.push({
                            session :item,
                            isSelected : false,
                        });
                    }
                }

            });
          })
          .finally(()=> this.hideLoading());
        }
    }
  
    private generateDays(index:number): string[] {
      const today = new Date();
      today.setDate(today.getDate() + index); 
      this.selectDate(today.toLocaleDateString('tr-GB', { day: '2-digit', month: 'long' }));
      this.filterResults();
  
  
      const days: string[] = [];
      for (let i = 0; i < this.daysVisible; i++) {
        const nextDay = new Date(today);
        nextDay.setDate(today.getDate() + i);
        const dayString = nextDay.toLocaleDateString('tr-GB', { day: '2-digit', month: 'long' });
        days.push(dayString);
      }
      return days;
    }
  
    public getDays(): string[] {
      return this.days;
    }
  
    @Watch('currentIndex')
    changeIndex(newDate: string) {
     console.log(this.currentIndex);   
     this.getDays();
  
    }
  
    public previous() {
      if (this.currentIndex > 0) {
        this.currentIndex --;
        this.days = this.generateDays(this.currentIndex);
        console.log(this.days)
      }
    }
  
    public next() {
      this.currentIndex ++;
      this.days = this.generateDays(this.currentIndex);
      console.log(this.days)
    } 
  
    selectDate(day: string) {
      this.selectedDate = day;
    }
  
    selectSession(id: number) {
        let oldSelectionSession = this.sessionSelectionCardDatas.find(x => x.isSelected);
        let newSelectionSession = this.sessionSelectionCardDatas.find(x => x.session.id == id);

        if (!oldSelectionSession && newSelectionSession) {
          newSelectionSession.isSelected = true;
            this.$emit('selectSessionForReservation', id);
            return;
        }

        if (oldSelectionSession && newSelectionSession) {
            if (oldSelectionSession.session.id == newSelectionSession.session.id) {
                return;
            } else {
              oldSelectionSession.isSelected = false;
                newSelectionSession.isSelected = true;
                this.$emit('selectSessionForReservation', id)
            }
        }
        return;
    }
  
    @Watch('selectedDate')
    onSelectedDateChanged(newDate: string) {
       this.filterResults();
    }


    @Watch('selectBranchForReservation')
    onSelectedBranchChange(newDate: string) {
        this.filterResults();
    }

    @Watch('selectMovieForReservation')
    onSelectedMovieChange(newDate: string) {
        this.filterResults();
    }


   
    filterResults() {
      this.sessionSelectionCardDatas = [];
      this.getAllSession();
    }
    
    nextItem (){
      console.log("next");
      this.currentIndex ++;
    }
  
    previousItem () {
      console.log("previous");
      this.currentIndex --;
    }
     
}
