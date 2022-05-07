import {CommunityType} from "./CommunityType";

export class Community{
    communityId!: number;
    communityTypeId?: number;
    communityType!: CommunityType;
    communityName!: string;
    communitySummary!: string;
}