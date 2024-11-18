import {Component} from 'vue-property-decorator';
import Base from "@/utils/Base";
import BranchCard from "@/components/branchCard/index.vue";
import {Repositories, RepositoryFactory} from "@/services/RepositoryFactory";
import {BranchRepository} from "@/Repositories/BranchRepository";
import BranchDto from "@/models/branch/BranchDto";


const _branchRepository = RepositoryFactory(Repositories.BranchRepository) as BranchRepository;

@Component({
    components:{
        BranchCard
    }
})
export default class Branches extends Base {

    branches : BranchDto[] = [];


    created(): void {
        const self = this;
        self.showLoading();
        _branchRepository.GetAllBranches()
            .then(x => {
                self.branches = x;
            })
            .finally(()=> self.hideLoading());
    }

    destroyed(): void {
    }

    mounted(): void {
    }


}