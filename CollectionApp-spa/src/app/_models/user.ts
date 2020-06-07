import { UserPhoto } from './userPhoto';

export interface User {
  id: number;
  username: string;
  photoUrl: string;
  created?: Date;
  knownAs?: string;
  introduction?: string;
  photos?: UserPhoto[];
  rank?: number;
}
