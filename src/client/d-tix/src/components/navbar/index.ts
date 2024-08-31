import { Component, Vue } from 'vue-property-decorator';

@Component
export default class Navbar extends Vue {

    menuExpandIconName: ExpandIcon = ExpandIcon.Menu;
    topPosition: ExpandPosition = ExpandPosition.Hide;

    changeMenuExpandIcon(){
        this.menuExpandIconName === ExpandIcon.Menu 
        ? this.menuExpandIconName = ExpandIcon.Close 
        : this.menuExpandIconName = ExpandIcon.Menu
        
        this.menuExpandIconName === ExpandIcon.Menu
        ? this.topPosition = ExpandPosition.Hide
        : this.topPosition = ExpandPosition.Show;
    }

}

enum ExpandIcon{
    Menu='menu',
    Close='close'
}

enum ExpandPosition{
    Show = 'top-[20%]',
    Hide = 'top-[-60%] '
}