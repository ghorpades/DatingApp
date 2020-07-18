import { Photo } from './photo';

export interface User {
    id: number;
    username: string;
    knownAs: string;
    age: number;
    gender: string;
    created: Date;
    lastActive: Date;
    photoURL: string;
    city: string;
    country: string;
    intrests?: string;
    introduction?: string;
    lookingfor?: string;
    photos?: Photo[];
}
