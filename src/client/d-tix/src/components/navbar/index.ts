import { Component, Vue } from 'vue-property-decorator';
import LoginResponse from "@/models/auth/LoginResponse";
import Base from "@/utils/Base";
import {GetAuthInfo, RemoveAuthInfo} from "@/services/AuthService";
import AxiosIstance from "@/utils/AxiosIstance";
import {Repositories, RepositoryFactory} from "@/services/RepositoryFactory";
import {BranchRepository} from "@/Repositories/BranchRepository";
import BranchDto from "@/models/branch/BranchDto";

const _branchRepository = RepositoryFactory(Repositories.BranchRepository) as BranchRepository;
@Component
export default class Navbar extends Base {

    auido: HTMLAudioElement | null = null;
    isMusicPlay:boolean = false;

    loginInfo: LoginResponse  | null= null;

    menuExpandIconName: ExpandIcon = ExpandIcon.Menu;
    topPosition: ExpandPosition = ExpandPosition.Hide;

    items: BranchDto[] = []
    values= []

    changeMenuExpandIcon(){
        this.menuExpandIconName === ExpandIcon.Menu 
        ? this.menuExpandIconName = ExpandIcon.Close 
        : this.menuExpandIconName = ExpandIcon.Menu
        
        this.menuExpandIconName === ExpandIcon.Menu
        ? this.topPosition = ExpandPosition.Hide
        : this.topPosition = ExpandPosition.Show;
    }


    created() {
        this.auido = new Audio('/a.mp3');

        this.$root.$on("loginSuccess", (r: LoginResponse)=>{

            this.loginInfo = r;
            console.log(this.loginInfo);
        });

        this.$bus.$on("logout", ()=>{
            this.logout();
        });

        this.loginInfo = GetAuthInfo();

        _branchRepository.GetAllBranches()
            .then(r => {
            this.items = r;
        });

    }

    hey(){
        this.$router.push({path:'/playground'})
    }
    music(){
        console.log('hello world');
        const self = this;
        if(!this.auido)
            return;

        if(this.isMusicPlay){
            this.auido.pause();
            this.auido.currentTime = 0;
            this.isMusicPlay = false;
        }else{
            this.auido.play();
            this.isMusicPlay = true;

            this.auido.onended = (e)=>{
                self.$toast.success("Müzik bitti :)");
                self.isMusicPlay = false;
            }
        }        
    }

    logout(){
        this.loginInfo = null;
        RemoveAuthInfo();
        AxiosIstance.defaults.headers["Authorization"] = `Bearer `;
        this.$toast("Çıkış yapıldı. Güle güle 🙌");
    }

    destroyed(): void {
        this.$root.$off("loginSuccess", ()=>{
            this.loginInfo = null;
        });

        this.$bus.$off("logout", ()=>{
            this.loginInfo = null;
        });
    }

    mounted(): void {
    }
}

enum ExpandIcon{
    Menu='menu',
    Close='close'
}

enum ExpandPosition{
    Show = 'tw-top-[67px]',
    Hide = 'tw-top-[-60%] '
}