import { PropsWithChildren } from "react";

type TProps = {
} & PropsWithChildren;

export const BasicContainer = ({ children }: TProps) => {
    return (
        <div className="min-w-[800px] justify-center flex mt-10">
            {children}
        </div>
    );
}