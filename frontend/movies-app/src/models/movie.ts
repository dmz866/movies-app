import { Actor } from "./actor";

export type Movie = {
    movieId: number;
    name: string;
    description: string;
    actors?: Actor[];
}