import { createContext } from 'react';
import { Actor } from '../../models';

export interface IActorContext {
    searchActorName?: string,
    actorsFound: Actor[],
    updateActorsFound: (value?: Actor[]) => void
    updateSearchActorName: (value?: string) => void

}

export const ActorContext = createContext<IActorContext>({
    searchActorName: '',
    updateSearchActorName: (value?: string) => { },
    updateActorsFound: (value?: Actor[]) => { },
    actorsFound: []
});