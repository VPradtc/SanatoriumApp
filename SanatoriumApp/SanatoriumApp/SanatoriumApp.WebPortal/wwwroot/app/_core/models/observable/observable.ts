module pinguinPortal.app.core.models.observable {

    export interface IObserver<T> {
        handle(arg: T): void;
    }

    export abstract class Observable<T> {
        protected observers: Array<IObserver<T>> = new Array<IObserver<T>>();
        protected lastModelState: T = null;

        public add(observer: IObserver<T>): void {
            this.observers.push(observer);
            observer.handle(this.lastModelState);
        }

        public remove(observer: IObserver<T>): void {
            let removeAt = this.observers.indexOf(observer);
            this.observers.splice(removeAt, 1);
        }

        public notify(model: T): void {
            this.lastModelState = model;
            this.observers.forEach(x => x.handle(this.lastModelState));
        }
    }
}
