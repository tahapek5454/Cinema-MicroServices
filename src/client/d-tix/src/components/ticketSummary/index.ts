import {Component, Prop, Vue} from 'vue-property-decorator';
import {BaseImagePath} from "@/constDatas";
import MovieDto from "@/models/movies/MovieDto";
import Base from "@/utils/Base";
import {Repositories, RepositoryFactory} from "@/services/RepositoryFactory";
import {MovieRepository} from "@/Repositories/MovieRepository";
import ReservationModel from "@/models/reservation/reservationModel";
import BranchDto from "@/models/branch/BranchDto";
import SessionDto from "@/models/session/SessionDto";
import {BranchRepository} from "@/Repositories/BranchRepository";
import {SessionRepository} from "@/Repositories/SessionRepository";
import SeatDto from "@/models/session/SeatDto";
import {GetAuthInfo} from "@/services/AuthService";

const _movieRepository = RepositoryFactory(Repositories.MovieRepository) as MovieRepository;
const _branchRepository = RepositoryFactory(Repositories.BranchRepository) as BranchRepository;
const _sessionRepository = RepositoryFactory(Repositories.SessionRepository) as SessionRepository;

@Component({
    components:{

    }
})
export default class TicketSummary extends Base {
    @Prop() reservationModel: ReservationModel;

    loginInfo = GetAuthInfo();
     movie: MovieDto  = new MovieDto();
     branch: BranchDto = new BranchDto();
     session: SessionDto = new SessionDto();
     seats: SeatDto[] = [];
     created() {
         this.showLoading();
         Promise.all([
             _movieRepository.GetMovieById('' + this.reservationModel.movieId)
                 .then(r => { this.movie = r; console.log(r); }),
             _sessionRepository.GetSessionById(this.reservationModel.sessionId as number)
                 .then(r => { this.session = r; console.log(r); }),
             _branchRepository.GetBrancheById('' + this.reservationModel.branchId)
                 .then(r => { this.branch = r; console.log(r); }),
             _sessionRepository.GetSeatsBySessionIdAndUserId(this.loginInfo?.userId as number, this.reservationModel.sessionId as number)
                 .then(r => {this.seats = r; console.log(r); })
         ])
             .catch(error => {
                 console.error('Error fetching data:', error);
             })
             .finally(() => this.hideLoading());

     }
     mounted(){

     }
     destroyed()  {

     }

     get SessionDate(){
         if(! (this.session?.date))
             return  '';

         const date = new Date(this.session.date);
         return date.toLocaleDateString('tr-TR', {
             year: 'numeric',
             month: '2-digit',
             day: '2-digit',
         });
     }

     get SessionHoursAndMinuets(){
         if(! (this.session?.date))
             return  '';

         const date = new Date(this.session.date);
         return date.toLocaleTimeString('tr-TR', {
             hour: '2-digit',
             minute: '2-digit',
         });
     }

     get CalculateTotalPrice(){
         if(!this.session || !this.seats)
             return '';

         let val = this.seats.length * this.session.price;
         return  ''+val;
     }

    get ImageValue(): string{
        if(!(this.movie.movieImages && this.movie.movieImages.length))
            return ``;

        return `${BaseImagePath}/${this.movie.movieImages[0].fileName}`;
    }

    get TimeValue(): string {
        const result = this.splitDouble(this.movie?.time as number);
        return `${result.integerPart} saat ${result.decimalPart} dakika.`;
    }


    private splitDouble(value: number): { integerPart: number, decimalPart: number } {

        if(value == null)
            return {
                integerPart:0,decimalPart:0
            }

        const integerPart = Math.floor(value);
        const decimalPart = Math.round((value - integerPart) * 100);

        return {
            integerPart,
            decimalPart
        };
    }
}