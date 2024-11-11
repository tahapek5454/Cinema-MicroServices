import { Component, Prop } from 'vue-property-decorator';
import Base from "@/utils/Base";
import { Repositories, RepositoryFactory } from "@/services/RepositoryFactory";
import { MovieRepository } from "@/Repositories/MovieRepository";
import MovieDto from "@/models/movies/MovieDto";
import MovieSelectionCard from "@/components/movieSelection/movieSelectionCard/index.vue";
import BranchDto from '@/models/branch/BranchDto';
import { BranchRepository } from '@/Repositories/BranchRepository';
import CityDto from '@/models/city/CityDto';
import DistrinctDto from '@/models/distrinct/DistrinctDto';
import { CityRepository } from '@/Repositories/CityRepository';
import { DistrinctRepository } from '@/Repositories/DistrinctRepository';
import BranchSelectionCard from './branchSelectionCard/index.vue';

const _cityRepository = RepositoryFactory(Repositories.CityRepository) as CityRepository;
const _distrinctRepository = RepositoryFactory(Repositories.DistrinctRepository) as DistrinctRepository;
const _branchRepository = RepositoryFactory(Repositories.BranchRepository) as BranchRepository;

interface BranchSelectionCardModel {
    branch: BranchDto;
    isSelected: boolean;
}

@Component({
    components: {
        BranchSelectionCard
    }
})
export default class BranchSelection extends Base {

    cities: CityDto[] = [];
    city = new CityDto();

    distrincts: DistrinctDto[] = [];
    distrinct = new DistrinctDto();

    branchSelectionCardDatas: BranchSelectionCardModel[] = [];
    itemCount: number = 0;

    created(): void {
        this.showLoading();
        _cityRepository.GetAllCities()
            .then((r) => {
                this.cities = r;
            })
            .finally(() => this.hideLoading());
    }

    cityChanged(event: any) {      
        if(event > 0) {
            this.distrincts = [];
            this.showLoading();
            _distrinctRepository.GetDistrictByCity(event.toString())
                .then((r) => {
                    this.distrincts = r;
                })
                .finally(() => this.hideLoading());
        }
        this.distrincts = [];
    }

    distrinctChanged(event: any) {
        if(event > 0) {
            this.branchSelectionCardDatas = [];
            this.showLoading();
            _branchRepository.GetBranchesByDistrinct(event.toString())
                .then((r) => {
                    r.forEach(item => {
                        this.branchSelectionCardDatas.push({
                            branch :item,
                            isSelected : false,
                        });
                    });
                })
                .finally(() => this.hideLoading());
        }
        this.branchSelectionCardDatas = [];
    }

    destroyed(): void {
    }

    mounted(): void {
    }

    selectBranch(id: number) {
        let oldSelectionBranch = this.branchSelectionCardDatas.find(x => x.isSelected);
        let newSelectionBranch = this.branchSelectionCardDatas.find(x => x.branch.id == id);

        if (!oldSelectionBranch && newSelectionBranch) {
            newSelectionBranch.isSelected = true;
            this.$emit('selectBranchForReservation', id);
            return;
        }

        if (oldSelectionBranch && newSelectionBranch) {
            if (oldSelectionBranch.branch.id == newSelectionBranch.branch.id) {
                return;
            } else {
                oldSelectionBranch.isSelected = false;
                newSelectionBranch.isSelected = true;
                this.$emit('selectBranchForReservation', id)
            }
        }
        return;
    }
}