import { Movie } from "./movie";

export type Actor = {
    actorId: number;
    name: string;
    description: string;
    imageUrl: string;
    movies: Movie[];
}