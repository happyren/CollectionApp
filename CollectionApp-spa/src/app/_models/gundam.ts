import { GundamPhoto } from './gundamPhoto';

export interface Gundam {
  id: number;
  modelName: string;
  grade: string;
  photoUrl: string;
  launchDate?: Date;
  brand?: string;
  series?: string;
  photos?: GundamPhoto[];
}
