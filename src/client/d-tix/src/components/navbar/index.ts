import { Component, Vue } from 'vue-property-decorator';
import LoginResponse from "@/models/auth/LoginResponse";
import Base from "@/utils/Base";
import {GetAuthInfo, RemoveAuthInfo} from "@/services/AuthService";
import AxiosIstance from "@/utils/AxiosIstance";


@Component
export default class Navbar extends Base {

    auido: HTMLAudioElement | null = null;
    isMusicPlay:boolean = false;

    loginInfo: LoginResponse  | null= null;

    menuExpandIconName: ExpandIcon = ExpandIcon.Menu;
    topPosition: ExpandPosition = ExpandPosition.Hide;

    items = ['Xyz Avm Sinemaları', 'Serdivan AVM Sinemaları', 'Agora Sienamalrı']
    values= ['Serdivan AVM Sinemaları']

    changeMenuExpandIcon(){
        this.menuExpandIconName === ExpandIcon.Menu 
        ? this.menuExpandIconName = ExpandIcon.Close 
        : this.menuExpandIconName = ExpandIcon.Menu
        
        this.menuExpandIconName === ExpandIcon.Menu
        ? this.topPosition = ExpandPosition.Hide
        : this.topPosition = ExpandPosition.Show;
        console.log('hello world');
    }


    created() {
        this.auido = new Audio('/a.mp3');

        this.$root.$on("loginSuccess", (r: LoginResponse)=>{

            this.loginInfo = r;
            console.log(this.loginInfo);
        });

        this.loginInfo = GetAuthInfo();

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