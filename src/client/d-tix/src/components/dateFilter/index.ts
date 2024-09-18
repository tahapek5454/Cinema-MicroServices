import { computed, watch } from 'vue';
import { Component, Vue, Watch } from 'vue-property-decorator';

@Component
export default class DateFilter extends Vue {
  days:string[]=[];
  visibleItems:string[]=[];
  daysVisible: number = 4;
  currentIndex: number = 0;

  created() {
    this.currentIndex = 0;
    this.days = this.generateDays(0);
  }

  private generateDays(index:number): string[] {
    const today = new Date();
    today.setDate(today.getDate() + index); 
    this.selectDate(today.toLocaleDateString('en-GB', { day: '2-digit', month: 'short' }));
    this.filterResults();


    const days: string[] = [];
    for (let i = 0; i < this.daysVisible; i++) {
      const nextDay = new Date(today);
      nextDay.setDate(today.getDate() + i);
      const dayString = nextDay.toLocaleDateString('en-GB', { day: '2-digit', month: 'short' });
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
  
  sessions: Session[] = [
    { time: '10:00', date: '19 Sept' },
    { time: '13:00', date: '19 Sept' },
    { time: '15:00', date: '19 Sept' },
    { time: '17:00', date: '19 Sept' },
    { time: '19:00', date: '19 Sept' },
    { time: '19:40', date: '19 Sept' },
    { time: '20:00', date: '19 Sept' },
    { time: '21:00', date: '19 Sept' },
    { time: '23:00', date: '19 Sept' },
    { time: '09:00', date: '20 Sept' },
    { time: '13:00', date: '20 Sept' },
    { time: '15:00', date: '20 Sept' },
    { time: '17:00', date: '20 Sept' },
    { time: '19:00', date: '20 Sept' },
    { time: '19:40', date: '20 Sept' },
    { time: '20:00', date: '20 Sept' },
    { time: '21:00', date: '20 Sept' },
    { time: '23:00', date: '20 Sept' },
    { time: '11:00', date: '21 Sept' },
    { time: '13:00', date: '21 Sept' },
    { time: '15:00', date: '21 Sept' },
    { time: '17:00', date: '21 Sept' },
    { time: '19:00', date: '21 Sept' },
    { time: '19:40', date: '21 Sept' },
    { time: '12:00', date: '22 Sept' },
    { time: '13:00', date: '23 Sept' },
    { time: '15:00', date: '23 Sept' },
    { time: '17:00', date: '18 Sept' },
    { time: '19:00', date: '18 Sept' },
    { time: '19:40', date: '18 Sept' },
    { time: '20:00', date: '18 Sept' },
    { time: '21:00', date: '18 Sept' },
  ];

  selectedDate: string = '';
  selectedSession:string='';
  filteredResults: Session[] = [];


  selectDate(day: string) {
    this.selectedDate = day;
  }

  selectSession(session: string) {
    this.selectedSession = session;
  }

  @Watch('selectedDate')
  onSelectedDateChanged(newDate: string) {
    this.filterResults();
  }



  filterResults() {
    if (this.selectedDate === '') {
      this.filteredResults = [];
    } else {
      this.filteredResults = this.sessions.filter(session => session.date === this.selectedDate);
    }
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

export class Session {
  time: string = '';
  date: string = '';
}
