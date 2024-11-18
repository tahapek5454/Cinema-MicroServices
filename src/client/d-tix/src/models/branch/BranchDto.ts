import DistrinctDto from "@/models/distrinct/DistrinctDto";

export default class BranchDto{
    id: number;
    name: string;
    address: string;
    description: string;
    districtId: number;
    district: DistrinctDto
}